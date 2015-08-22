using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.DAL;
using WorkHour.DAL;

namespace WorkHour.Models
{
    // ReSharper disable once InconsistentNaming
    public class WHDBcontent:IDisposable
    {
        public WHDBcontent ()
        {
            Whdb=new WHDB();
            AccountDal=new AccountDal(this);
            MemberDal=new MemberDal(this);
        }
        public WHDB Whdb { get; }
        public AccountDal AccountDal { get; private set; }
        public MemberDal MemberDal { get; private set; }
        public void Dispose()
        {
            Whdb.Dispose();
        }
    }
}