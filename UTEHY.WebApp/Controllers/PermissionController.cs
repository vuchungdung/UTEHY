using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTEHY.Service.Interfaces;

namespace UTEHY.WebApp.Controllers
{
    public class PermissionController : Controller
    {
        IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetCommandView()
        {
            var result = _permissionService.GetCommandViews();
            if(result != null)
            {
                return Json(new { result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new {  }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}