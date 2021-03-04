using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTEHY.Service.Interfaces;

namespace UTEHY.WebApp.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IMenuService _menuService;

        public HomeController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Menu()
        {
            var responseData = _menuService.GetAll();
            return PartialView(responseData);
        }
    }
}