using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTEHY.WebApp.Common
{
    [Serializable]
    public class UserLogin
    {
        public string UserName { set; get; }
        public string UserId { set; get; }
        public string GroupId { set; get; }
        public string Name { set; get; }
    }
}