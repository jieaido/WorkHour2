using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using WorkHour.Models;

namespace WorkHour.Controllers
{
    public class MembersController : Controller
    {
        private WHDB db = new WHDB();
        private WHDBcontent db2=new WHDBcontent();
        // GET: Members

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string mname,string mpwd)
        {

            Session["account"]= db2.Whdb.Accounts.FirstOrDefault();
            return Content("OK");
        }
        public ActionResult Index()
        {
            var members = db.Members.Include(m => m.Team);
            return View(members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName");
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
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", member.TeamID);
            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", member.TeamID);
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
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", member.TeamID);
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
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
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult register()
        {
            var s = db.Teams.ToList();
             var sl=new SelectList(s, "TeamID", "TeamName");
            ViewBag.selectlist = sl;
            return View();
        }

        [HttpPost]
        public ActionResult register(string mname,string mpwd,int teamid)
        {
            //todo

            //增加注册画面
            Member member=new Member()
            {
                MemberName = mname,
               // MemberPwd = mpwd,
                
            };
            member.TeamID = teamid;
            member.Team = db2.Whdb.Teams.FirstOrDefault(x => x.TeamID == teamid);
            if (db2.MemberDal.Register(member)!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            return  View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
