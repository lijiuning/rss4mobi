using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using NavigationRoutes;

namespace Rss4Mobi.NavigationRoutes
{
    public class NavigationRouteFilter:INavigationRouteFilter
    {
        public bool ShouldRemove(Route navigationRoutes)
        {
            
            //是否登陆
            bool islogined = (HttpContext.Current.User.Identity.Name != "");

            var r = navigationRoutes as NamedRoute;

            if (r != null)
            {
                if (r.Name.Equals("Navigation-Account-Index", StringComparison.OrdinalIgnoreCase))
                {
                    if(islogined)
                    {
                        r.DisplayName = HttpContext.Current.User.Identity.Name + " 的账户";
                    }
                    return !islogined;
                }
                if (r.Name.Equals("Navigation-Member-LogOn", StringComparison.OrdinalIgnoreCase))
                {
                    return islogined;
                }
                if (r.Name.Equals("Navigation-Member-Register", StringComparison.OrdinalIgnoreCase))
                {
                    return islogined;
                }
            }

            return false;
        }
    }
}