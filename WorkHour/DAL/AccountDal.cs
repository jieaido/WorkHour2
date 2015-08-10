using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHour.Models;

namespace Model.DAL
{
    public  class AccountDal
    {
       
        private WHDBcontent db;

        public AccountDal(WHDBcontent _db)
        {
            db = _db;
        }
        public Account ValiValidationAccount(Account account)
        {
            var s= db.Whdb.Accounts.FirstOrDefault(x => x.AccountName == account.AccountName && x.AccountPwd == account.AccountPwd);
            if (s==null)
            {
                return null;
            }

            return s;
        }

        public Account Register(Account account)
        {
            var s = db.Whdb.Accounts.Add(account);
            if (db.Whdb.SaveChanges() > 0)
            {
                return s;
            }
            
            return null;
        }
    }
}
