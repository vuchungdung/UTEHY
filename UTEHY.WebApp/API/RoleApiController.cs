using System.Web.Http;
using UTEHY.Infrastructure.Interfaces;
using UTEHY.Infrastructure.Utilities;
using UTEHY.Model.Entities;
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
            var result = _roleService.GetAll();
            return Ok();
        }
    }
}
