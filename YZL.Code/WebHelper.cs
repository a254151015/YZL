using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace YZL.Code
{
    public class WebHelper
    {
        private static HttpRequest request = HttpContext.Current.Request;
        /// <summary>是否是ajax提交方式
        /// </summary>
        /// <returns></returns>
        public static bool IsAjax()
        {
            
            HttpRequestBase requestBase = new HttpRequestWrapper(request);
            return requestBase.IsAjaxRequest();
        }
        /// <summary>获得IP
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string ip = String.Empty;
            ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if(string.IsNullOrEmpty(ip)){
                ip = request.ServerVariables["REMOTE_ADDR"];
            }
            if(string.IsNullOrEmpty(ip)){
                ip = request.UserHostAddress;
            }
            if (string.IsNullOrEmpty(ip))
            {
                ip = "127.0.0.1";
            }
            return ip;
        }
    }
}
