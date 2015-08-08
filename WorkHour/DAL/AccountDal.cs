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
        private readonly WHDB _db=new WHDB();
        public Account ValiValidationAccount(Account account)
        {
            var s= _db.Accounts.FirstOrDefault(x => x.AccountName == account.AccountName && x.AccountPwd == account.AccountPwd);
            if (s==null)
            {
                return null;
            }

            return s;
        }
        
    }
}
