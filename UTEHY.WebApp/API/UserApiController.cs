using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using UTEHY.Service.Interfaces;
using UTEHY.WebApp.App_Start;

namespace UTEHY.WebApp.API
{
    [RoutePrefix("api/userapi")]
    [Authorize]
    public class UserApiController : ApiController
    {
        private IUserService _userService;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public UserApiController()
        {

        }

        public UserApiController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, IUserService userService)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _userService = userService;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<HttpResponseMessage> Login(HttpRequestMessage request, string userName, string password, bool rememberMe)
        {
            if (!ModelState.IsValid)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            var result = await SignInManager.PasswordSignInAsync(userName, password, rememberMe, shouldLockout: false);
            return request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("logout")]
        [Authorize]
        public HttpResponseMessage Logout(HttpRequestMessage request)
        {
            var claim = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Sid).Value;
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return request.CreateResponse(HttpStatusCode.OK, new { success = true });
        }
        [HttpGet]
        [Route("getmenu")]
        [AllowAnonymous]
        public HttpResponseMessage GetMenuByUserPermission(HttpRequestMessage request)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var id = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (id == null)
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var responData = _userService.GetMenuByUserPermission(id);
                if (responData != null)
                {
                    return request.CreateResponse(HttpStatusCode.OK, new { responData });
                }
                return request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi hệ thống");
            }
        }
    }
}
