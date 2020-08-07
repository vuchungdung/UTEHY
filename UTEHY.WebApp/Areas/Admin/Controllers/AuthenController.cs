using System.Security.Claims;
using System.Web.Mvc;
using UTEHY.Model.Entities;
using UTEHY.Model.ViewModel;
using UTEHY.Service.Interfaces;

namespace UTEHY.WebApp.Areas.Admin.Controllers
{
    public class AuthenController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }        
        
    }
}