using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YZL.BaseController.BaseAdminController;


namespace YZL.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController//  Controller
    {
        private ITestService _ITestService;

        public HomeController(ITestService iTestService)
        {
            _ITestService = iTestService;
        }

        //
        // GET: /Admin/Home/
        public ActionResult Index()
        {
            //var userName = CurrentLoginUser;
            string str = _ITestService.GetStr();

            return View();
        }

        public ActionResult Manager()
        {

            return View();
        }
	}
}