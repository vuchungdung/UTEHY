using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTEHY.Model.Dtos;
using UTEHY.Model.ViewModel;
using UTEHY.Service.Interfaces;
using UTEHY.WebApp.Common;

namespace UTEHY.WebApp.Areas.Admin.Controllers
{
    public class PostController : BaseController
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
                    var user = (UserLogin)Session[UserCommon.USER_SESSION];
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
    }
}