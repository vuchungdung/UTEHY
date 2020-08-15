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
using UTEHY.WebApp.Core;

namespace UTEHY.WebApp.API
{
    [RoutePrefix("api/postapi")]
    [Authorize]
    public class PostApiController : ApiControllerBase
    {
        private IPostService _postService;

        public PostApiController(IPostService postService,IErrorService errorService):base(errorService)
        {
            _postService = postService;
        }    
        [Route("getpaging")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage GetAllPaging(HttpRequestMessage request, [FromBody]PageRequest pageRequest)
        {
            return CreateHttpResponse(request, () =>
            {
                var responseData = _postService.GetAllPaging(pageRequest);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }     
        [Route("addpost")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage AddPost(HttpRequestMessage request, [FromBody]PostViewModel postVm)
        {
            return CreateHttpResponse(request, () =>
            {
                var responseData = _postService.Add(postVm);
                _postService.Save();
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("delete")]
        [HttpDelete]       
        [AllowAnonymous]
        public HttpResponseMessage DeletePost(HttpRequestMessage request, string postId)
        {
            return CreateHttpResponse(request, () =>
            {
                var responseData = _postService.Delete(postId);
                _postService.Save();
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("changestatus")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage ChangeStatus(HttpRequestMessage request, string id, PostStatus status)
        {
            return CreateHttpResponse(request, () =>
            {
                var responseData = _postService.ChangeStatus(id, status);
                _postService.Save();
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}
