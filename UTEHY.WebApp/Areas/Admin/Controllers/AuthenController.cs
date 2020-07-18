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
        //public void setCookie(string username, bool rememberme = false, string role = "normal")
        //{
        //    var authTicket = new FormsAuthenticationTicket(
        //                       1,
        //                       username,
        //                       DateTime.Now,
        //                       DateTime.Now.AddMinutes(120),
        //                       rememberme,
        //                       role
        //                       );

        //    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

        //    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
        //    Response.Cookies.Add(authCookie);
        //}
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Login(model);
                if (result == 1)
                {
                    var user = _userService.GetUserByUserName(model.UserName);
                    //setCookie(user.UserName, model.RememberMe, user.GroupId);
                    var userSession = new UserLogin();
                    userSession.UserId = user.UserId;
                    userSession.UserName = user.UserName;
                    userSession.GroupId = user.GroupId;
                    userSession.Name = user.Name;
                    Session.Add(UserCommon.USER_SESSION, userSession);
                    var listPermission = _permissionService.GetAllPermission();
                    Session.Add(UserCommon.PERMISSION_SESSION, listPermission);
                    return RedirectToAction("Index", "Home");
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
        
    }
}