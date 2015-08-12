using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Model;
using WorkHour.Models;

namespace WorkHour.Areas.admin.Controllers
{
    public class AdminController : Controller
    {
        WHDBcontent db=new WHDBcontent();
        // GET: admin/admin
        public ActionResult Index()
        {
            return Content("admin");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost ]
        public ActionResult Login( string username,string password)
        {
            Account account = new Account()
            {
                AccountName = username,
                AccountPwd = password
            };
            var s = db.AccountDal.ValiValidationAccount(account);
            if ( s!=null)
            {
              FormsAuthentication.SetAuthCookie(s.Accountid.ToString(),false);
              Session["account"] = s;
              return  RedirectToAction("Index", "Permissions");
                    
            }
            return View();
        }
    }
}