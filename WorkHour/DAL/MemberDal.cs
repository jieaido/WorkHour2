using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using WorkHour.Models;

namespace WorkHour.DAL
{
    public class MemberDal
    {
        private WHDBcontent db;

        public MemberDal(WHDBcontent _db)
        {
            db = _db;
        }

        public Member ValiValidationAccount(Member member)
        {
            //todo

            //var s = db.Whdb.Members.FirstOrDefault(x => x.MemberName == member.MemberName && x.MemberPwd == member.MemberPwd);
            //if (s == null)
            //{
            //    return null;
            //}

            return null;
        }

        public Member Register(Member member)
        {
            //todo
            //增加注册逻辑
            var s = db.Whdb.Members.Add(member);
            if (db.Whdb.SaveChanges() > 0)
            {
                return s;
            }
            return null;





        }

        public List<Member> GetMembers(int[] ids)
        {
            List<Member> members = new List<Member>();
            foreach (var id in ids)
            {
                members.Add(db.Whdb.Members.Find(id));
            }
            return members;
            return null;
        }
    }
}