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
    [RoutePrefix("api/postcategoryapi")]
    [Authorize]
    public class PostCategoryApiController : ApiControllerBase
    {
        public PostCategoryApiController(IErrorService errorService) : base(errorService)
        {
        }
    }
}
