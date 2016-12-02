using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using YZL.Code;

namespace YZL.BaseController.BaseAdminController
{
    public class BaseAdminController : BaseController
    {
        public static string CurrentLoginUser { get {

            return "";
        } }
        /// <summary>验证是否登录
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            //if (WebHelper.IsAjax())
            //{

            //}
            //else
            //{

            //}
        }
    }
}
