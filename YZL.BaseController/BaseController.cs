using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace YZL.BaseController
{
    public abstract class BaseController : Controller
    {
        public BaseController()
        {

        }
        /// <summary>调用此方法之前调用
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        /// <summary>调用此方法后调用
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        /// <summary>在进行授权时调用。(先执行OnAuthentication)
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnAuthentication(System.Web.Mvc.Filters.AuthenticationContext filterContext)
        {
            base.OnAuthentication(filterContext);
        }

        /// <summary>在进行授权时调用。（后执行OnAuthorization）
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        

        /// <summary>所有异常抛出
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

       
    }
}
