using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace YZL
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "YZL.Areas.Web.Controllers" }
            ).DataTokens.Add("Area", "Web");
           // routes.MapRoute(
           //     "Default",
           //    "{controller}/{action}/{id}",
           //    new { controller = "Home", action = "Index", id = UrlParameter.Optional }, //这里要和Admin块下的默认控制器和action一样  
           //    new[] { "YZL.HomeController" }// 这个是你控制器所在命名空间  
           //).DataTokens.Add("Area", "Web");  
        }
    }
}
