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
               
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LogOut()
        {
            Session.Clear();
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}