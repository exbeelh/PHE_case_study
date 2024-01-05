using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SupplyManagement
{
    public class AuthenticatedRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return httpContext.User.Identity.IsAuthenticated;
        }
    }

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { authenticated = new AuthenticatedRouteConstraint() }
            );

            routes.MapRoute(
                name: "DefaultUnauthenticated",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
