using UTEHY.WebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTEHY.Model.ViewModel;

namespace UTEHY.WebApp.Authorization
{
    public class AuthorizationAttribute : AuthorizeAttribute
    {
        public string FunctionId { set; get; }
        public string CommandId { set; get; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return true;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/Error.cshtml"
            };
        }
        //private List<PermissionViewModel> GetAllPermissionByUserName(string userName)
        //{
            
        //}
    }
}