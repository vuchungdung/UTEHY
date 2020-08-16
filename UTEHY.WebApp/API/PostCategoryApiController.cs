using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UTEHY.Model.Dtos;
using UTEHY.Model.ViewModel;
using UTEHY.Service.Interfaces;
using UTEHY.WebApp.Core;

namespace UTEHY.WebApp.API
{
    [RoutePrefix("api/postcategoryapi")]
    [Authorize]
    public class PostCategoryApiController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;

        public PostCategoryApiController(IErrorService errorService,IPostCategoryService postCategoryService) : base(errorService)
        {
            _postCategoryService = postCategoryService;
        }
        [Route("getpaging")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage GetAllPaging(HttpRequestMessage request, [FromBody]PageRequest pageRequest)
        {
            return CreateHttpResponse(request, () =>
            {
                var responseData = _postCategoryService.GettAllPaging(pageRequest);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Add(HttpRequestMessage request, [FromBody]PostCategoryViewModel postVm)
        {
            return CreateHttpResponse(request, () =>
            {
                var responseData = _postCategoryService.Add(postVm);
                _postCategoryService.Save();
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, string postId)
        {
            return CreateHttpResponse(request, () =>
            {
                var responseData = _postCategoryService.Delete(postId);
                _postCategoryService.Save();
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, [FromBody]PostCategoryViewModel postVm)
        {
            return CreateHttpResponse(request, () =>
            {
                var responseData = _postCategoryService.Update(postVm);
                _postCategoryService.Save();
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("getall")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var responseData = _postCategoryService.GetAll();
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("getsingle")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetSignle (HttpRequestMessage request,string id)
        {
            return CreateHttpResponse(request, () =>
            {
                var responseData = _postCategoryService.GetSingleById(id);
                _postCategoryService.Save();
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}
