using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace NavigationRoutes
{
    public class NamedRoute : Route
    {
         string _name;
        private string _resource;
         string _displayName;
         List<NamedRoute> _childRoutes = new List<NamedRoute>();

         public NamedRoute(string name, string url, IRouteHandler routeHandler, string resource)
            : base(url, routeHandler)
        {
            _name = name;
             _resource = resource;
        }

        public NamedRoute(string name, string url, RouteValueDictionary defaults, RouteValueDictionary constraints,
                          IRouteHandler routeHandler, string resource)
            : base(url, defaults, constraints, routeHandler)
        {
            _name = name;
            _resource = resource;
        }

        public NamedRoute(string name, string url, RouteValueDictionary defaults, RouteValueDictionary constraints,
                          RouteValueDictionary dataTokens, IRouteHandler routeHandler, string resource)
            : base(url, defaults, constraints, dataTokens, routeHandler)
        {
            _name = name;
            _resource = resource;
        }

        public NamedRoute(string name, string displayName, string url, RouteValueDictionary defaults, RouteValueDictionary constraints,
                          RouteValueDictionary dataTokens, IRouteHandler routeHandler, string resource)
            : base(url, defaults, constraints, dataTokens, routeHandler)
        {
            _name = name;
            _displayName = displayName;
            _resource = resource;
        }

        public NamedRoute(string name, string displayName, string url, MvcRouteHandler routeHandler, string resource)
            : base(url, routeHandler)
        {
            _name = name;
            _displayName = displayName;
            _resource = resource;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string DisplayName
        {
            get { return CultureName()??Name; }
            set { _displayName = value; }
        }

        public string CultureName()
        {
            try
            {
                var n = Resources.Content.ResourceManager.GetString(_resource);
                return n;
            }
            catch
            {
                return _displayName;
            }
        }

        public List<NamedRoute> Children { get { return _childRoutes; } }
        public bool IsChild { get; set; }
    }
}