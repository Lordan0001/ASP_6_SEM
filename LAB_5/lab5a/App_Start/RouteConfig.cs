﻿using System.Web.Mvc;
using System.Web.Routing;

namespace lab5a
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: null,
                 url: "CResearch/{action}",
                 defaults: new { controller = "CResearch", action = "C01", id = UrlParameter.Optional }

                );



            routes.MapRoute(
                name: null,
                url: "V2/{controller}/{action}/",
                defaults: new { controller = "MResearch", action = "M02", id = UrlParameter.Optional },
                constraints: new { action = "^M02$|^M01$|^$" }
               );

            routes.MapRoute(
                name: null,
                url: "V3/{controller}/{X}/{action}/",
                defaults: new { controller = "MResearch", action = "M03", X = UrlParameter.Optional },
                constraints: new { X = "^X$|^$" }
                );

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MResearch", action = "M01", id = UrlParameter.Optional },
                new { action = "^M02$|^M01$" }
            );
            routes.MapRoute(
                null,
                "{*url}",
                new { controller = "MResearch", action = "MXX" }
            );

        }
    }
}
