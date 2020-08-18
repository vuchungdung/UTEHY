using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using UTEHY.Infrastructure.Utilities;
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
        private Logger _logger;

        public PostApiController(IPostService postService, Logger logger)
        {
            _postService = postService;
            _logger = logger;
        }    
        [Route("getpaging")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult GetAllPaging([FromBody]PageRequest pageRequest)
        {
            try
            {
                var responseData = _postService.GetAllPaging(pageRequest);
                return Ok(responseData);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error at method: GetAllPaging - PostApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
            
        }     
        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Add([FromBody]PostViewModel postVm)
        {
            try
            {
                var responseData = _postService.Add(postVm);
                _postService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: Add - PostApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("delete")]
        [HttpDelete]       
        [AllowAnonymous]
        public IHttpActionResult Delete(string postId)
        {
            try
            {
                var responseData = _postService.Delete(postId);
                _postService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: Delete - PostApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("changestatus")]
        [HttpPut]
        [AllowAnonymous]
        public IHttpActionResult ChangeStatus(string id, PostStatus status)
        {
            try
            {
                var responseData = _postService.ChangeStatus(id, status);
                _postService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: ChangeStatus - PostApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
    }
}
