using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Model;
using WorkHour.Models;

namespace WorkHour.code
{
    public class WHinit:DropCreateDatabaseIfModelChanges<WHDB>
    {
        protected override void Seed(WHDB context)
        {
            base.Seed(context);
            var s = new Account
            {
                AccountName = "admin",
                AccountPwd = "admin"
            };
            context.Accounts.Add(s);
            context.SaveChanges();
        }
    }
}