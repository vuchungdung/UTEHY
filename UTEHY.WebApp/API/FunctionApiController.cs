using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UTEHY.Service.Interfaces;

namespace UTEHY.WebApp.API
{
    [RoutePrefix("api/functionapi")]
    [Authorize]
    public class FunctionApiController : ApiController
    {
        public FunctionApiController()
        {
        }
    }
}
