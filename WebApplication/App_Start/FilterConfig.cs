using System.Web;
using System.Web.Mvc;
using WebApplication.Filters;

namespace WebApplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandleErrorAttribute());
            //filters.Add(new HandleErrorAttribute());
        }
    }
}
