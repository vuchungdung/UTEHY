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
    public class FacultyApiController : ApiController
    {
        private readonly IFacultyService _facultyService;
        private Logger _logger;

        public FacultyApiController(IFacultyService facultyService, Logger logger)
        {
            _facultyService = facultyService;
            _logger = logger;
        }

        public IHttpActionResult GetAllPaging([FromBody] PageRequest pageRequest)
        {
            try
            {
                var responseData = _facultyService.GetAllPaging(pageRequest);
                return Ok(responseData);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error at method: GetAllPaging - FacultyApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Add([FromBody] FacultyViewModel facultyVm)
        {
            try
            {
                var responseData = _facultyService.Add(facultyVm);
                _facultyService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: Add - FacultyApi," + ex.InnerException.InnerException.Message + "");
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
                var responseData = _facultyService.Delete(postId);
                _facultyService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: Delete - FacultyApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public IHttpActionResult Update([FromBody] FacultyViewModel facultyVm)
        {
            try
            {
                var responseData = _facultyService.Update(facultyVm);
                _facultyService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: Update - FacultyApi," + ex.InnerException.InnerException.Message + "");
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
                var responseData = _facultyService.GetAll();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: GetAll - FacultyApi," + ex.InnerException.InnerException.Message + "");
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
                var responseData = _facultyService.GetSingle(id);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: GetSingle - FacultyApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
    }
}
