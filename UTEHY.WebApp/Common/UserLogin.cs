using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT.WebApp.Common
{
    [Serializable]
    public class UserLogin
    {
        public string UserName { set; get; }
        public Guid UserId { set; get; }
        public Guid GroupId { set; get; }
        public string Name { set; get; }
    }
}