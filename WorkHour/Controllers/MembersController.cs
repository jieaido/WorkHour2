using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using WorkHour.code;
using WorkHour.Models;

namespace WorkHour.Controllers
{
    public class MembersController : Controller
    {
        private WHDB _db = new WHDB();
        private WHDBcontent _db2=new WHDBcontent();
        // GET: Members

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string mname,string mpwd)
        {
            //todo
           //这个回来要集中做登录处理

            WhUser.Getcurrentuser().SetValue(_db2.Whdb.Accounts.FirstOrDefault());
                
            Session["account"]= _db2.Whdb.Accounts.FirstOrDefault();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Index()
        {
            var members = _db.Members.Include(m => m.Team);
            return View(members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = _db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
           
            if (WhUser.Getcurrentuser()!=null)
            {
                int id = WhUser.Getcurrentuser().TeamId;
                ViewBag.TeamID = new SelectList(_db.Teams, "TeamID", "TeamName");
            }
            else
            {
                ViewBag.TeamID = new SelectList(_db.Teams, "TeamID", "TeamName");

            }
            return View();
        }

        // POST: Members/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberID,MemberName,TeamID")] Member member)
        {
            if (ModelState.IsValid)
            {
                _db.Members.Add(member);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamID = new SelectList(_db.Teams, "TeamID", "TeamName", member.TeamID);
            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = _db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamID = new SelectList(_db.Teams, "TeamID", "TeamName", member.TeamID);
            return View(member);
        }

        // POST: Members/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberID,MemberName,TeamID")] Member member)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(member).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamID = new SelectList(_db.Teams, "TeamID", "TeamName", member.TeamID);
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = _db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = _db.Members.Find(id);
            _db.Members.Remove(member);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Register()
        {
            var s = _db.Teams.ToList();
             var sl=new SelectList(s, "TeamID", "TeamName");
            ViewBag.selectlist = sl;
            return View();
        }

        [HttpPost]
        public ActionResult Register(string mname,string mpwd,int teamid)
        {
            //todo
         
            //增加注册画面
            Account account = new Account()
            {
                AccountName = mname,
                AccountPwd = mpwd,
                TeamId = teamid,
                IsAdmin = false
            };
        
            if (_db2.AccountDal.Register(account)!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            return  View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
