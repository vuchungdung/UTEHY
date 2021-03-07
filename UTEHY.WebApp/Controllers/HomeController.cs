using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTEHY.Model.Entities;
using UTEHY.Model.ViewModel;
using UTEHY.Service.Interfaces;

namespace UTEHY.WebApp.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IMenuService _menuService;
        private readonly FITDbContext _db;

        public HomeController(IMenuService menuService, FITDbContext db)
        {
            _menuService = menuService;
            _db = db;
        }

        public ActionResult Index()
        {
            var listResult = new HomeViewModel();

            listResult.ThongBaos = _db.Posts.Where(x => x.CategoryId == "7d2e0b22-a9aa-432b-9fa0-b025e152e720")
                                            .Select(x => new PostViewModel()
                                            {
                                                Name = x.Name,
                                                Description = x.Description,
                                                Img = x.Img,
                                                CreateDate = x.CreateDate
                                            }).OrderBy(x=>x.CreateDate).ToList();
            listResult.TinNoiBats = _db.Posts.Where(x => x.CategoryId == "7d2e0b22-a9aa-432b-9fa0-b025e152e720" && x.HomeFlag == true)
                                            .Select(x => new PostViewModel()
                                            {
                                                Name = x.Name,
                                                Description = x.Description,
                                                Img = x.Img,
                                                CreateDate = x.CreateDate
                                            }).OrderBy(x=>x.CreateDate).ToList();
            listResult.TinTucs = _db.Posts.Where(x => x.Deleted == false)
                                            .Select(x => new PostViewModel()
                                            {
                                                Name = x.Name,
                                                Description = x.Description,
                                                Img = x.Img,
                                                CreateDate = x.CreateDate
                                            }).OrderBy(x=>x.CreateDate).ToList();
            listResult.TinTuyenDung = _db.Posts.Where(x => x.CategoryId == "b45ed418-5515-4faa-a7d5-1bc27b4a959e")
                                            .Select(x => new PostViewModel()
                                            {
                                                Name = x.Name,
                                                Description = x.Description,
                                                Img = x.Img,
                                                CreateDate = x.CreateDate
                                            }).OrderBy(x => x.CreateDate).ToList();
            listResult.BaiGhim = _db.Posts.Where(x => x.HotFlag == true)
                                            .Select(x => new PostViewModel()
                                            {
                                                Name = x.Name,
                                                Description = x.Description,
                                                Img = x.Img,
                                                CreateDate = x.CreateDate
                                            }).FirstOrDefault();
            return View(listResult);
        }

        [HttpGet]
        public ActionResult Menu()
        {
            var responseData = _menuService.GetAll();
            return PartialView(responseData);
        }
    }
}