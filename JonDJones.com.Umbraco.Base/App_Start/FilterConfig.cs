using System.Web;
using System.Web.Mvc;

namespace JonDJones.com.Umbraco.Base
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
