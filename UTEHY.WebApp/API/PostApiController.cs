using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using UTEHY.Model.Dtos;
using UTEHY.Model.Enums;
using UTEHY.Model.ViewModel;
using UTEHY.Service.Interfaces;

namespace UTEHY.WebApp.API
{
    [RoutePrefix("api/postapi")]
    [Authorize]
    public class PostApiController : ApiController
    {
        private IPostService _postService;

        public PostApiController(IPostService postService)
        {
            _postService = postService;
        }    
        [Route("getpaging")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetAllPaging(HttpRequestMessage request, string keyword, string categoryId, PageRequest pageRequest)
        {
            var result = _postService.GetAllPaging(keyword, categoryId, pageRequest);
            if (result != null)
            {
                return request.CreateResponse(HttpStatusCode.OK, request);
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }     
        [Route("addpost")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage AddPost(HttpRequestMessage request, PostViewModel postVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = User.Identity;
                    postVm.CreatedBy = user.Name;
                    var result = _postService.Add(postVm);
                    if (result == true)
                    {
                        _postService.Save();
                        return request.CreateResponse(HttpStatusCode.OK, result);
                    }
                    else
                    {
                        return request.CreateResponse(HttpStatusCode.BadRequest);
                    }
                }
                catch (Exception error)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest,error);
                }
            }
            return request.CreateResponse(HttpStatusCode.BadRequest);
        }
        [Route("delete")]
        [HttpDelete]       
        [AllowAnonymous]
        public HttpResponseMessage DeletePost(HttpRequestMessage request, string postId)
        {
            if (postId != null)
            {
                var result = _postService.Delete(postId);
                if (result != null)
                {
                    _postService.Save();
                    return request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            return request.CreateResponse(HttpStatusCode.BadRequest);
        }
        [Route("changestatus")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage ChangeStatus(HttpRequestMessage request, string id, PostStatus status)
        {
            var result = _postService.ChangeStatus(id, status);
            _postService.Save();
            return request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
