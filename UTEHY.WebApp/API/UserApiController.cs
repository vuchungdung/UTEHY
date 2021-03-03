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
using UTEHY.Infrastructure.Utilities;
using UTEHY.Model.Constants;
using UTEHY.Model.Dtos;
using UTEHY.Model.ViewModel;
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
        private Logger _logger;
        public UserApiController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, IUserService userService,Logger logger)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _userService = userService;
            _logger = logger;
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
        public IHttpActionResult LogOut()
        {           
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return Ok();
        }

        [HttpGet]
        [Route("getmenu")]
        [Authorize]
        [ClaimRequirementFilter(Function = FunctionCode.SYSTEM_USER,Command = CommandCode.VIEW)]
        public IHttpActionResult GetMenuByUserPermission()
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var id = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                //var khoa = identity.FindFirst(ClaimTypes.Country).Value;                
                var responData = _userService.GetMenuByUserPermission(id);
                return Ok(responData);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error at method: GetMenuByUserPermission - UserApi, "+ ex.Message + "");
                return BadRequest("Error System");
            }
        }

        [HttpPost]
        [Route("getpaging")]
        [Authorize]
        public IHttpActionResult GetAllPaging([FromBody] PageRequest pageRequest)
        {
            try
            {
                var responseData = _userService.GetAllPaging(pageRequest);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: GetAllPaging - UserApi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
    }
}
