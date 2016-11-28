
using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YZL.App_Start;

namespace YZL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            new AutoFacContainer();
            //DependencyResolver.SetResolver(new AutoFacContainer());
            //ObjectContainer.ApplicationStart(new AutoFacContainer());
        }
    }
}
