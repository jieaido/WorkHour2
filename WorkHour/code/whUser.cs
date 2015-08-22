using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebSockets;
using Model;

namespace WorkHour.code
{
    ///登陆用户类
    public class WhUser
    {
        private  static WhUser _whUser;
        public static WhUser Getcurrentuser()
        {
            if (_whUser==null)
            {
                _whUser =new WhUser();
            }
            return _whUser;

        }
        public WhUser(Account account)
        {
            SetValue(account);
        }

        public void SetValue(Account account)
        {
            WhRoles = account.WhRoles;
            Accountid = account.TeamId;
            AccountName = account.AccountName;
            AccountPwd = account.AccountPwd;
            IsAdmin = account.IsAdmin;
            TeamId = account.TeamId;
            IsCanLogin = account.IsCanLogin;
        }

        public WhUser()
        {
            
        }

        public int Accountid { get; set; }
        
        public string AccountName { get; set; }
        public string AccountPwd { get; set; }
        public bool IsCanLogin { get; set; }
        public bool IsAdmin { get; set; }
        public int TeamId { get; set; }
        public virtual ICollection<WhRole> WhRoles { get; set; }
    }
}