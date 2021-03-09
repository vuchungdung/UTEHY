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
    [RoutePrefix("api/menuapi")]
    [Authorize]
    public class MenuApiController : ApiController
    {
        private IMenuService _menuService;
        private Logger _logger;

        public MenuApiController(IMenuService menuService, Logger logger)
        {
            _menuService = menuService;
            _logger = logger;
        }
        [Route("getpaging")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult GetAllPaging([FromBody] PageRequest pageRequest)
        {
            try
            {
                var responseData = _menuService.GetAllPaging(pageRequest);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: GetAllPaging - MenuApi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Add([FromBody] MenuViewModel postVm)
        {
            try
            {
                var responseData = _menuService.Add(postVm);
                _menuService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: Add - MenuApi," + ex.Message + "");
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
                var responseData = _menuService.Delete(postId);
                _menuService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: Delete - MenuApi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public IHttpActionResult Update([FromBody] MenuViewModel postVm)
        {
            try
            {
                var responseData = _menuService.Update(postVm);
                _menuService.Save();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: Update - MenuApi," + ex.Message + "");
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
                var responseData = _menuService.GetAll();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: GetAll - MenuApi," + ex.Message + "");
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
                var responseData = _menuService.GetSingleById(id);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at method: GetSingle - MenuApi," + ex.Message + "");
                return BadRequest("Error System");
            }
        }
    }
}
