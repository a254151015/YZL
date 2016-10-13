using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YZL.BaseController.BaseAdminController;

namespace YZL.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController//Controller
    {
        //
        // GET: /Admin/Home/
        public ActionResult Index()
        {
            var userName = CurrentLoginUser;
            return View();
        }

        public ActionResult Manager()
        {

            return View();
        }
	}
}