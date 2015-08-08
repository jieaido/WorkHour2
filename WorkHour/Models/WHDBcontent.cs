using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.DAL;
using WorkHour.DAL;

namespace WorkHour.Models
{
    public class WHDBcontent
    {
        public WHDBcontent ()
        {
            Whdb=new WHDB();
            AccountDal=new AccountDal();
            MemberDal=new MemberDal(this);
        }
        public WHDB Whdb { get; private set; }
        public AccountDal AccountDal { get; private set; }
        public MemberDal MemberDal { get; private set; }
    }
}