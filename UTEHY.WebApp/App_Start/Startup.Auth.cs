using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Owin;
using UTEHY.Model.Constants;
using UTEHY.Model.Entities;
using UTEHY.Service.AuthorizeService;

[assembly: OwinStartup(typeof(UTEHY.WebApp.App_Start.Startup))]

namespace UTEHY.WebApp.App_Start
{
    public partial class Startup
    {
        public void ConfiguraAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(FITDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            app.CreatePerOwinContext<UserManager<User>>(CreateManager);
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/oauth/token"),
                Provider = new AuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                AllowInsecureHttp = true,
            });
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
        public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
        {

            //Login với identity owin
            public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                context.Validated();
            }
            public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
                var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");

                if (allowedOrigin == null) allowedOrigin = "*";

                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

                UserManager<User> userManager = context.OwinContext.GetUserManager<UserManager<User>>();
                ProfileService profile = new ProfileService();
                User user;
                try
                {
                    user = await userManager.FindAsync(context.UserName, context.Password);
                }
                catch
                {
                    context.SetError("server_error");
                    context.Rejected();
                    return;
                }
                if (user != null)
                {
                    ClaimsIdentity identity = await userManager.CreateIdentityAsync(
                                                            user,
                                                            DefaultAuthenticationTypes.ExternalBearer);
                    var roles = userManager.GetRoles(user.Id);
                    var permission = profile.GetProfileService(roles);
                    
                    var claims = new List<Claim>();
                    //claims.Add(new Claim(ClaimTypes.Country, user.FacultyId));
                    claims.Add(new Claim(ClaimTypes.UserData, user.FullName));
                    claims.Add(new Claim(SystemContants.Claims.Permissions, JsonConvert.SerializeObject(permission)));
                    identity.AddClaims(claims);
                    context.Validated(identity);
                }
                else
                {
                    context.SetError("invalid_grant", "Tài khoản hoặc mật khẩu không đúng.'");
                    context.Rejected();
                }
            }
        }
        private static UserManager<User> CreateManager(IdentityFactoryOptions<UserManager<User>> options, IOwinContext context)
        {
            var userStore = new UserStore<User>(context.Get<FITDbContext>());
            var owinManager = new UserManager<User>(userStore);
            return owinManager;
        }

    }
}
