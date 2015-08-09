using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Model;
using WorkHour.Models;

namespace WorkHour.code
{
    public class Guolv : Controller
    {
        WHDB db=new  WHDB();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string cname = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
            string aname = filterContext.ActionDescriptor.ActionName.ToLower();
            string actiontype = filterContext.HttpContext.Request.RequestType.ToLower();
            Account account = Session["Account"] as Account;
            //这是上一个网页
            //天才
            if (account != null)
            {
                account = db.Accounts.Find(account.Accountid);
              
                var lasturl = filterContext.HttpContext.Request.UrlReferrer;

                if (account.IsAdmin)
                {
                    return;
                }
                    var ssList =(from a in account.WhRoles
                        from p in a.Permissions
                                                             
                        select  p ).Distinct() ;
                            
                    foreach (var p in ssList)
                    {
                    
                        if (p.ControllName.ToLower()==cname&&p.ActionName==null&&p.ActionType==null)
                        {
                            return;
                        }
                        if (p.ControllName.ToLower()==cname&&p.ActionName==aname&&p.ActionType==null)
                        {
                            return;
                        }
                        if (p.ControllName.ToLower() == cname && p.ActionName == aname && p.ActionType.ToLower() == actiontype)
                        {
                            return;
                        }

                    }
               // filterContext.HttpContext.Response.Redirect(lasturl != null ? lasturl.AbsoluteUri : "/Home/Index");
                filterContext.HttpContext.Response.Redirect(lasturl?.AbsoluteUri ?? "/Home/Index");
            }
            if (account == null)
            {
                //todo 返回登陆页
                filterContext.HttpContext.Response.Redirect("/Home/Index");

            }
        }
    }

}