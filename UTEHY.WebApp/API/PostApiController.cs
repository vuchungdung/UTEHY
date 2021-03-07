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
                _logger.LogError("Error at method: GetAllPaging - PostApi," + ex.Message + "");
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
                _logger.LogError("Error at method: Add - PostApi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("approve")]
        [HttpDelete]
        [AllowAnonymous]
        public IHttpActionResult Approve(string postId)
        {
            try
            {
                var responseDate = _postService.Approve(postId);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError("Error at method: Add - PostApi," + ex.Message + "");
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
                _logger.LogError("Error at method: Delete - PostApi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("changestatus")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult ChangeStatus(StatusRequest request)
        {
            try
            {
                var responseData = _postService.ChangeStatus(request.Id, request.Status);
                _postService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: ChangeStatus - PostApi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("changehot")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult ChangeHot([FromBody] HotFlagRequest request)
        {
            try
            {
                var responseData = _postService.ChangeHot(request.Id, request.Status);
                _postService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: ChangeHot - PostApi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("changehome")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult ChangeHomeFlag([FromBody] HomeFlagRequest request)
        {
            try
            {
                var responseData = _postService.ChangeFlag(request.Id, request.Status);
                _postService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: ChangeHot - PostApi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetById(string id)
        {
            try
            {
                var responseData = _postService.GetPostById(id);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: GetById - PostApi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
    }
}
