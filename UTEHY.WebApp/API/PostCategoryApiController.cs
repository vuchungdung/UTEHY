using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UTEHY.Infrastructure.Utilities;
using UTEHY.Model.Dtos;
using UTEHY.Model.ViewModel;
using UTEHY.Service.Interfaces;

namespace UTEHY.WebApp.API
{
    [RoutePrefix("api/postcategoryapi")]
    [Authorize]
    public class PostCategoryApiController : ApiController
    {
        private IPostCategoryService _postCategoryService;
        private Logger _logger;

        public PostCategoryApiController(IPostCategoryService postCategoryService,Logger logger)
        {
            _postCategoryService = postCategoryService;
            _logger = logger;
        }
        [Route("getpaging")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult GetAllPaging([FromBody]PageRequest pageRequest)
        {
            try
            {
                var responseData = _postCategoryService.GettAllPaging(pageRequest);
                return Ok(responseData);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error at method: GetAllPaging - PostCategoryApi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Add([FromBody]PostCategoryViewModel postVm)
        {
            try
            {
                var responseData = _postCategoryService.Add(postVm);
                _postCategoryService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: Add - PostCategoryApi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public IHttpActionResult Delete([FromUri]string postId)
        {
            try
            {
                var responseData = _postCategoryService.Delete(postId);
                _postCategoryService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: Delete - PostCategoryApi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public IHttpActionResult Update([FromBody]PostCategoryViewModel postVm)
        {
            try
            {
                var responseData = _postCategoryService.Update(postVm);
                _postCategoryService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: Update - PostCategoryApi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("getall")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetAll()
        {
            try
            {
                var responseData = _postCategoryService.GetAll();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: GetAll - PostCategoryApi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("getsingle")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetSignle ([FromUri]string id)
        {
            try
            {
                var responseData = _postCategoryService.GetSingleById(id);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: GetSingle - PostCategoryApi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
    }
}
