using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using UTEHY.Model.Entities;
using UTEHY.Model.ViewModel;
using static UTEHY.WebApp.App_Start.Startup;

[assembly: OwinStartup(typeof(UTEHY.WebApp.App_Start.Startup))]

namespace UTEHY.WebApp.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
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
            public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                context.Validated();
            }
            public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
                var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");

                if (allowedOrigin == null) allowedOrigin = "*";

                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });
                FITEntities _db = new FITEntities();
                User user;
                try
                {
                    user = await _db.Users.FindAsync(context.UserName,context.Password);
                }
                catch
                {
                    context.SetError("server_error");
                    context.Rejected();
                    return;
                }
                if (user != null)
                {
                    ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
                    identity.AddClaim(new Claim(ClaimTypes.UserData, user.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.Role, user.GroupId));
                    identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                    identity.AddClaim(new Claim(ClaimTypes.Sid, user.UserId));
                    context.Validated(identity);
                }
                else
                {
                    context.SetError("invalid_grant", "Tài khoản hoặc mật khẩu không đúng.'");
                    context.Rejected();
                }
            }
        }
    }
}
