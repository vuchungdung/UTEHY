using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTEHY.Model.ViewModel;
using UTEHY.Service.Interfaces;

namespace UTEHY.WebApp.Areas.Admin.Controllers
{
    public class PostCategoryController : BaseController
    {
        private IPostCategoryService _postCategoryService;
        public PostCategoryController(IPostCategoryService postCategoryService)
        {
            _postCategoryService = postCategoryService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _postCategoryService.GetAll();
            if(result != null)
            {
                return Json(new { result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new {  }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult AddCategory(PostCategoryViewModel postCategoryVm)
        {
            try
            {
                var result = _postCategoryService.Add(postCategoryVm);
                _postCategoryService.Save();
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { ex }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPut]
        public JsonResult UpdateCategory(PostCategoryViewModel postCategoryVm)
        {
            try
            {
                var result = _postCategoryService.Update(postCategoryVm);
                _postCategoryService.Save();
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpDelete]
        public JsonResult DeleteCategory(string categoryId)
        {
            var result = _postCategoryService.Delete(categoryId);
            if (result == true)
            {
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}