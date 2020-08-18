using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UTEHY.Service.Interfaces;

namespace UTEHY.WebApp.API
{
    [RoutePrefix("api/teacherapi")]
    [Authorize]
    public class TeacherApiController : ApiController
    {
        public TeacherApiController()
        {
        }
    }
}
