using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using UTEHY.Model.Dtos;
using UTEHY.Model.Entities;
using UTEHY.Model.Enums;
using UTEHY.Model.ViewModel;
using UTEHY.Service.Interfaces;
using UTEHY.WebApp.Common;

namespace UTEHY.WebApp.Controllers
{
    public class PostController : Controller
    {
        private IPostService _postService;
        private IPostCategoryService _postCategoryService;
        private readonly FITDbContext _db;

        public PostController(IPostService postService, 
            IPostCategoryService postCategoryService,
            FITDbContext db)
        {
            _postService = postService;
            _postCategoryService = postCategoryService;
            _db = db;
        }

        public ActionResult Index()
        {
            var listItem = _postService.GetAll();
            return View(listItem);
        }
        public ActionResult Category()
        {
            var listItem = _postCategoryService.GetAll();
            return PartialView(listItem);
        }
        public ActionResult PostRelate(string categoryId)
        {
            var listItem = _db.Posts.Select(x => new PostViewModel()
            {
                Name = x.Name,
                ID = x.PostId,
                Img = x.Img,
                CreateDate = x.CreateDate
            }).OrderBy(x=>x.CreateDate).ToList();
            if (!String.IsNullOrEmpty(categoryId))
            {
                listItem = listItem.Where(x => x.CategoryId == categoryId).ToList();
            }
            return PartialView(listItem);
        }
        public ActionResult PostDetail(string id)
        {
            var result = _postService.GetPostById(id);
            return View(result);
        }
    }
}