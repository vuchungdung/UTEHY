using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTEHY.Model.Entities;
using UTEHY.WebApp.Common;

namespace UTEHY.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());            
        }       
    }
}
