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
    [RoutePrefix("api/facultyapi")]
    [Authorize]
    public class TemplateApiController : ApiController
    {
        private readonly ITemplateService _templateService;
        private Logger _logger;

        public TemplateApiController(ITemplateService templateService, Logger logger)
        {
            _templateService = templateService;
            _logger = logger;
        }

        public IHttpActionResult GetAllPaging([FromBody] PageRequest pageRequest)
        {
            try
            {
                var responseData = _templateService.GetAllPaging(pageRequest);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: GetAllPaging - TemplateApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Add([FromBody] TemplateViewModel templateVm)
        {
            try
            {
                var responseData = _templateService.Add(templateVm);
                _templateService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: Add - TemplateApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public IHttpActionResult Delete([FromUri] string postId)
        {
            try
            {
                var responseData = _templateService.Delete(postId);
                _templateService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: Delete - TemplateApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public IHttpActionResult Update([FromBody] TemplateViewModel templateVm)
        {
            try
            {
                var responseData = _templateService.Update(templateVm);
                _templateService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: Update - TemplateApi," + ex.InnerException.InnerException.Message + "");
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
                var responseData = _templateService.GetAll();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: GetAll - TemplateApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("getsingle")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetSignle([FromUri] string id)
        {
            try
            {
                var responseData = _templateService.GetSingle(id);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: GetSingle - TemplateApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
    }
}
