using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTEHY.Model.Dtos;
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
        public JsonResult GetAll()
        {
            var result = _postCategoryService.GetAll();
            if(result.Count() > 0)
            {
                return Json(new { result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetCategoryById(string id)
        {
            var result = _postCategoryService.GetSingleById(id);
            if (result != null)
            {
                return Json(new { result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllPaging(string keyword, PageRequest request)
        {
            var result = _postCategoryService.GettAllPaging(keyword,request);
            if (result != null)
            {
                return Json(new { result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult AddCategory(PostCategoryViewModel postCategoryVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _postCategoryService.Add(postCategoryVm);
                    _postCategoryService.Save();
                    return Json(new { result = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult UpdateCategory(PostCategoryViewModel postCategoryVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _postCategoryService.Update(postCategoryVm);
                    if(result != null)
                    {
                        _postCategoryService.Save();
                        return Json(new { result }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(null, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult DeleteCategory(string categoryId)
        {
            if(categoryId != null)
            {
                var result = _postCategoryService.Delete(categoryId);
                if (result != null)
                {
                    _postCategoryService.Save();
                    return Json(new { result }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}