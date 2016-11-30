using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YZL.Code;


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
            Exception innerEx = GerInnerException(filterContext.Exception);
            string msg = innerEx.Message;
            base.OnException(filterContext);
            Log.Error(msg, innerEx);

            if (!(innerEx is YZLException))
            {
                var controllerName = filterContext.RouteData.Values["controller"].ToString();
                var actionName = filterContext.RouteData.Values["action"].ToString();
                var areaName = filterContext.RouteData.DataTokens["area"];
                var erroMsg = string.Format("页面未捕获的异常：Area:{0},Controller:{1},Action:{2}", areaName, controllerName, actionName);
                Log.Error(erroMsg, innerEx);
                msg = "系统内部异常";
            }

            if (WebHelper.IsAjax())
            {
                Result result = new Result();
                result.success = false;
                result.msg = msg;
                result.status = -9999;
                filterContext.Result = Json(result);
                //将状态码更新为200，否则在Web.config中配置了CustomerError后，Ajax会返回500错误导致页面不能正确显示错误信息
                filterContext.HttpContext.Response.StatusCode = 200;
                filterContext.ExceptionHandled = true;
                DisposeService(filterContext);
            }
            else
            {
            }


            if (innerEx is HttpRequestValidationException)
            {
                if (WebHelper.IsAjax())
                {
                    Result result = new Result();
                    result.msg = "您提交了非法字符!";
                    filterContext.Result = Json(result);
                }
                else
                {
                    var result = new ContentResult();
                    result.Content = "<script src='/Scripts/jquery-1.11.1.min.js'></script>";
                    result.Content += "<script src='/Scripts/jquery.artDialog.js'></script>";
                    result.Content += "<script src='/Scripts/artDialog.iframeTools.js'></script>";
                    result.Content += "<link href='/Content/artdialog.css' rel='stylesheet' />";
                    result.Content += "<link href='/Content/bootstrap.min.css' rel='stylesheet' />";
                    result.Content += "<script>$(function(){$.dialog.errorTips('您提交了非法字符！',function(){window.history.back(-1)},2);});</script>";
                    filterContext.Result = result;
                }
                filterContext.HttpContext.Response.StatusCode = 200;
                filterContext.ExceptionHandled = true;
                DisposeService(filterContext);
            }
        }

        protected Exception GerInnerException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return GerInnerException(ex.InnerException);
            }
            else
            {
                return ex;
            }
        }
        /// <summary>释放内存
        /// </summary>
        /// <param name="filterContext"></param>
        void DisposeService(ControllerContext filterContext)
        {
            if (filterContext.IsChildAction)
                return;

            List<IService.IService> services = filterContext.HttpContext.Session["_serviceInstace"] as List<IService.IService>;
            if (services != null)
            {
                foreach (var service in services)
                {
                    try
                    {
                        service.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Log.Error(service.GetType().ToString() + "释放失败！", ex);
                    }
                }
                filterContext.HttpContext.Session["_serviceInstace"] = null;
            }
        }
    }
    public class Result
    {
        /// <summary>是否成功
        /// </summary>
        public bool success { get; set; }
        /// <summary>消息
        /// </summary>
        public string msg { get; set; }
        /// <summary>状态
        /// <para>1表成功</para>
        /// </summary>
        public int status { get; set; }
        /// <summary>数据
        /// </summary>
        public object Data { get; set; }
    }
}
