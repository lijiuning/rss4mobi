using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NavigationRoutes;
using Rss4Mobi.Controllers;

namespace BootstrapMvcSample
{
    public class LayoutsRouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapNavigationRoute<HomeController>(Resources.Content.Home, c => c.Index(),"Home");
            routes.MapNavigationRoute<AccountController>(Resources.Content.Register, c => c.Register(), "Register");
            routes.MapNavigationRoute<AccountController>(Resources.Content.LogOn, c => c.LogOn(), "LogOn");
            routes.MapNavigationRoute<AccountController>(Resources.Content.Account, c => c.Index(),"Account")
                .AddChildRoute<AccountController>(Resources.Content.Setting, c => c.Setting(),"Setting")
                .AddChildRoute<AccountController>(Resources.Content.MyFeeds, c => c.MyFeeds(), "MyFeeds")
                .AddChildRoute<AccountController>(Resources.Content.LogOut, c => c.LogOut(), "LogOut");
            routes.MapNavigationRoute<AboutController>(Resources.Content.About, c => c.Index(),"About");

            
            routes.MapRoute(
                name: "normal",
                url: "{controller}/{action}",
                defaults: new {controller = "Home", action = "Index"}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );

            routes.MapRoute(
                "Mail",
                "Account/Activation/{id}/{code}",
                new { controller = "Account", action = "Activation", id = "", code = "" }
                );
        }
    }
}
