using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTEHY.Service.Interfaces;
using UTEHY.WebApp.Common;

namespace UTEHY.WebApp.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetMenuByUserPermission()
        {
            var userSession = (UserLogin)Session[UserCommon.USER_SESSION];
            var result = _userService.GetMenuByUserPermission(userSession.UserId);
            if(result!= null)
            {
                return Json(new { result }, JsonRequestBehavior.AllowGet );
            }
            else
            {
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}