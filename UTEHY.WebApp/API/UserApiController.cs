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
using UTEHY.Model.Constants;
using UTEHY.Service.Interfaces;
using UTEHY.WebApp.App_Start;
using UTEHY.WebApp.Authorization;

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
        [Route("logout")]
        [Authorize]
        public HttpResponseMessage LogOut(HttpRequestMessage request)
        {           
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return request.CreateResponse(HttpStatusCode.OK, new { success = true });
        }
        [HttpGet]
        [Route("getmenu")]
        [AllowAnonymous]
        [ClaimRequirementFilter(Function = FunctionCode.SYSTEM_USER,Command = CommandCode.VIEW)]
        public HttpResponseMessage GetMenuByUserPermission(HttpRequestMessage request)
        {
            if(User.Identity.IsAuthenticated == true)
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
            else
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi hệ thống");
            }
        }
    }
}
