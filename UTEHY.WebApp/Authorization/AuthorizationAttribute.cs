using UTEHY.WebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTEHY.Model.ViewModel;

namespace UTEHY.WebApp.Authorization
{
    public class AuthorizationAttribute 
    {
        public string FunctionId { set; get; }
        public string CommandId { set; get; }       
    }
}