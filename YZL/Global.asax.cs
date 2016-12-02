
using YZL.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YZL.App_Start;
using YZL.Code;

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
            // 在应用程序启动时运行的代码
            Log.StartLog();
            //QuartzHelper.Start();
            //TopshelfHelper.StartTopshelf();
            //DependencyResolver.SetResolver(new AutoFacContainer());
            //ObjectContainer.ApplicationStart(new AutoFacContainer());
        }
    }
}
