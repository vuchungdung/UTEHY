﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UTEHY.WebApp.API
{
    [RoutePrefix("api/commandapi")]
    [Authorize]
    public class CommandApiController : ApiController
    {
    }
}
