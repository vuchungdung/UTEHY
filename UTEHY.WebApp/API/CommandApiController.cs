using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UTEHY.Service.Interfaces;
using UTEHY.WebApp.Core;

namespace UTEHY.WebApp.API
{
    [RoutePrefix("api/commandapi")]
    [Authorize]
    public class CommandApiController : ApiControllerBase
    {
        public CommandApiController(IErrorService errorService) : base(errorService)
        {
        }
    }
}
