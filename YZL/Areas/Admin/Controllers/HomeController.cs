
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YZL.BaseController.BaseAdminController;
using YZL.IServices;


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
            //string str = _ITestService.GetStr();

            return View();
        }

        public JsonResult List(int pageSize , int pageNumber)
        {
            IList<Test> tList = new List<Test>();
            tList.Add(new Test { Id = 1, Name = "测试1" });
            tList.Add(new Test { Id = 2, Name = "测试2" });
            tList.Add(new Test { Id = 3, Name = "测试3" });
            tList.Add(new Test { Id = 4, Name = "测试4" });
            tList.Add(new Test { Id = 5, Name = "测试5" });
            tList.Add(new Test { Id = 6, Name = "测试6" });
            tList.Add(new Test { Id = 7, Name = "测试7" });
            tList.Add(new Test { Id = 8, Name = "测试8" });
            tList.Add(new Test { Id = 9, Name = "测试9" });
            tList.Add(new Test { Id = 10, Name = "测试10" });
            tList.Add(new Test { Id = 11, Name = "测试11" });
            tList.Add(new Test { Id = 12, Name = "测试12" });
            tList.Add(new Test { Id = 13, Name = "测试13" });
            tList.Add(new Test { Id = 14, Name = "测试14" });
            tList.Add(new Test { Id = 15, Name = "测试15" });
            tList.Add(new Test { Id = 16, Name = "测试16" });
            if (pageNumber >= 1)
            {
                pageNumber = pageNumber - 1;
            }
            else
            {
                pageNumber = 0;
            }


            tList = tList.OrderBy(t => t.Id).Skip(pageNumber * pageSize).Take(pageSize).ToList();
            return Json(new
            {
                total = 16,
                rows = tList
            });
        }

        public ActionResult Manager()
        {
            _ITestService.AddStudents();
            _ITestService.QueryStudents();
            _ITestService.UpdateStudents();
            //_ITestService.TestLog4j();
            return View();
        }

        
	}
    public class Test
    {
        public int Id { get; set; }
        /// <summary>姓名
        /// </summary>
        public string Name { get; set; }
    }
}