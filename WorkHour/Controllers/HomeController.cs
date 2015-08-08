using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkHour.code;

namespace WorkHour.Controllers
{
    public class HomeController : Controller
    {
        [yonghu]//用户名称过滤
        public ActionResult Index()
        {
            
            var s = User.Identity.Name;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
                                                    return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}