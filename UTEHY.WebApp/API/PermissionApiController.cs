using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using UTEHY.Infrastructure.Interfaces;
using UTEHY.Infrastructure.Utilities;
using UTEHY.Model.Entities;
using UTEHY.Service.Interfaces;

namespace UTEHY.WebApp.API
{
    [RoutePrefix("api/permissionapi")]
    [Authorize]
    public class PermissionApiController : ApiController
    {
        private IPermissionService _permissionService;
        private Logger _logger;

        public PermissionApiController(IPermissionService permissionService, Logger logger) 
        {
            _permissionService = permissionService;
            _logger = logger;
        }
        [HttpGet]
        [Route("getcommandview")]
        public IHttpActionResult GetCommandView([FromUri] string roleId)
        {
            try
            {
                var responseData = _permissionService.GetCommandViews(roleId);
                return Ok(responseData);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error at method: GetCommandView - permissionapi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }

        [HttpGet]
        [Route("getprofile")]
        public IHttpActionResult GetPermissionAuth()
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var roleid = identity.FindFirst(ClaimTypes.Role).Value;
                var responseData = _permissionService.GetProfileService(roleid);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: GetCommandView - permissionapi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
    }
}
