using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkHour.code;
using WorkHour.Models;

namespace WorkHour.Controllers
{
    public class testController : Guolv
    {
        WHDB db=new  WHDB();
        // GET: test
        public ActionResult Index()
        {
            
            
            return Content("你看到说明你有权限");
        }
        public ActionResult haha()
        {


            return Content("你看到说明你有权限-haha");
        }
    }
}