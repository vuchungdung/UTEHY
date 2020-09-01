using System;
using System.Web.Http;
using UTEHY.Infrastructure.Utilities;
using UTEHY.Model.Dtos;
using UTEHY.Model.ViewModel;
using UTEHY.Service.Interfaces;

namespace UTEHY.WebApp.API
{
    [RoutePrefix("api/roleapi")]
    public class RoleApiController : ApiController
    {
        private IRoleService _roleService;
        private Logger _logger;
        public RoleApiController(IRoleService roleService, Logger logger)
        {
            _roleService = roleService;
            _logger = logger;
        }
        [HttpGet]
        [Route("getall")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var responseData = _roleService.GetAll();
                return Ok(responseData);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error at method: GetAll - RoleApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
        [HttpPost]
        [Route("getpaging")]
        public IHttpActionResult GetAllPaging([FromBody]PageRequest request)
        {
            try
            {
                var responseData = _roleService.GetAllPaging(request);
                return Ok(responseData);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error at method: GetPaging - RoleApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add([FromBody]RoleViewModel model)
        {
            try
            {
                var responseData = _roleService.Add(model);
                return Ok(responseData);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error at method: Add - RoleApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
        [HttpGet]
        [Route("getsingle")]
        public IHttpActionResult GetSingle([FromUri] string id)
        {
            try
            {
                var responseData = _roleService.GetSingle(id);
                return Ok(responseData);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error at method: GetSingle - RoleApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update([FromBody] RoleViewModel model)
        {
            try
            {
                var responseData = _roleService.Update(model);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: Update - RoleApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete([FromUri] string id)
        {
            try
            {
                var responseData = _roleService.Delete(id);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: Delete - RoleApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
        [HttpGet]
        [Route("getpermission")]
        public IHttpActionResult GetPermission([FromUri] string roleId)
        {
            try
            {
                var responseData = _roleService.GetPermissionByRoleId(roleId);
                return Ok(responseData);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error at method: GetPermission - RoleApi," + ex.InnerException.InnerException.Message + "");
                return BadRequest("Error System");
            }
        }
    }
}
