using FIT.WebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTEHY.Model.ViewModel;

namespace FIT.WebApp.Authorization
{
    public class AuthorizationAttribute : AuthorizeAttribute
    {
        public string FunctionId { set; get; }
        public string CommandId { set; get; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (UserLogin)HttpContext.Current.Session[UserCommon.USER_SESSION];
            if (session == null)
            {
                return false;
            }

            List<PermissionViewModel> listPermission = this.GetAllPermissionByUserName(session.UserName);

            if (listPermission.Single(x=>x.CommandId==CommandId && x.FunctionId == FunctionId).GroupId == session.GroupId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/Error.cshtml"
            };
        }
        private List<PermissionViewModel> GetAllPermissionByUserName(string userName)
        {
            var credentials = (List<PermissionViewModel>)HttpContext.Current.Session[UserCommon.PERMISSION_SESSION];
            return credentials;
        }
    }
}