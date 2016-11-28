using System.Web.Mvc;

namespace YZL.Areas.Web
{
    public class WebAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Web";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Web_default",
                "{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}