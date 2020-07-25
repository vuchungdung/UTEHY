using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UTEHY.Model.ViewModel;
using UTEHY.Service.Interfaces;
using UTEHY.WebApp.Common;

namespace UTEHY.WebApp.Areas.Admin.Controllers
{
    public class AuthenController : Controller
    {
        IUserService _userService;
        IPermissionService _permissionService;
        public AuthenController(IUserService userService, IPermissionService permissionService)
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
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }
            Session.Clear();
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Login(model);
                if (result == 1)
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
                    return RedirectToAction("Index","Home");
                }
                else if (result == -1)
                {
                    ViewBag.Error = "Tài khoản chưa được đăng ký!";
                    return View();
                }
                else
                {
                    ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác!";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác!";
                return View();
            }
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login", "Authen");
        }
    }
}