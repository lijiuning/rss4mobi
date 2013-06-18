using System.Web;
using System.Web.Mvc;
using NavigationRoutes;
using Rss4Mobi.NavigationRoutes;

namespace Rss4Mobi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            NavigationFilter.Filters.Add(new NavigationRouteFilter());
            filters.Add(new HandleErrorAttribute());
        }



    }
}