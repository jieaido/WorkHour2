using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace WorkHour.code
{
    public class yonghu : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            //todo
            //获得访问的action名称,controll名称,以及是post还是get,我真牛逼

            var t = filterContext.HttpContext.Request.RequestType;
            var a= filterContext.ActionDescriptor.ActionName;
            var c = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            base.OnAuthorization(filterContext);
        }
    }
    
}