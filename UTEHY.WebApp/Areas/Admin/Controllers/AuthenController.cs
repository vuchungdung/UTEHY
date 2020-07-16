using FIT.WebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTEHY.Model.ViewModel;
using UTEHY.Service.Interfaces;

namespace FIT.WebApp.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    public class AuthenController : Controller
    {
        IUserService _userService;
        IPermissionService _permissionService;
        public AuthenController(IUserService userService,IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }    
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(LoginViewModel model)
        {
            var result = _userService.Login(model);
            if (result == true)
            {
                var user = _userService.GetUserByUserName(model.UserName);
                var userSession = new UserLogin();
                userSession.UserId = user.UserId;
                userSession.UserName = user.UserName;
                userSession.GroupId = user.GroupId;
                userSession.Name = user.Name;
                Session.Add(UserCommon.USER_SESSION, userSession);
                var listPermission = _permissionService.GetAllPermission();
                Session.Add(UserCommon.PERMISSION_SESSION, listPermission);
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}