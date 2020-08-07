using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using UTEHY.Model.Dtos;
using UTEHY.Model.Entities;
using UTEHY.Model.ViewModel;
using UTEHY.Service.Implementation;
using UTEHY.Service.Interfaces;
using UTEHY.WebApp.Common;

namespace UTEHY.WebApp.Controllers
{
    public class AuthenController : Controller
    {
        IUserService _userService;
        public AuthenController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.FindUser(model);
                var userSession = new UserLogin();
                userSession.UserId = user.UserId;
                userSession.UserName = user.UserName;
                userSession.GroupId = user.GroupId;
                user.Name = user.Name;
                Session.Add(UserCommon.USER_SESSION, userSession);

                var tokemModel = GetJWTContainer(user);
                IAuthenService authService = new AuthenService(tokemModel.SecretKey);
                string token = authService.GenerateToken(tokemModel);
                if (!authService.IsTokenValid(token))
                    throw new UnauthorizedAccessException();
                else
                    return Json(token, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        private JWTContainer GetJWTContainer(User user)
        {
            return new JWTContainer()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.UserData, user.UserName),
                    new Claim(ClaimTypes.Sid, user.UserId),
                    new Claim(ClaimTypes.Role, user.GroupId)
                }
            };
        }
        public JsonResult LogOut()
        {
            Session.Clear();
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}