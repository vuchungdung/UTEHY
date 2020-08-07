using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using UTEHY.Model.Dtos;
using UTEHY.Model.Enums;
using UTEHY.Model.ViewModel;
using UTEHY.Service.Interfaces;
using UTEHY.WebApp.Common;

namespace UTEHY.WebApp.Controllers
{
    public class PostController : Controller
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllPaging(string keyword, PageRequest request, string groupId)
        {
            var result = _postService.GetAllPaging(keyword, groupId, request);
            if (result != null)
            {
                return Json(new { result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult AddPost(PostViewModel postVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = HttpContext.User.Identity;
                    postVm.CreatedBy = user.Name;
                    var result = _postService.Add(postVm);
                    if(result == true)
                    {
                        _postService.Save();
                        return Json(new { result = true }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(null, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception error)
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeletePost(string postId)
        {
            if (postId != null)
            {
                var result = _postService.Delete(postId);
                if (result != null)
                {
                    _postService.Save();
                    return Json(new { result }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChangeStatus(string id, PostStatus status)
        {
            var result =_postService.ChangeStatus(id, status);
            _postService.Save();
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}