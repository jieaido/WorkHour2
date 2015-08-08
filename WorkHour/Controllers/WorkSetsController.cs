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
    public class WorkSetsController : Controller
    {
        private WHDB db = new WHDB();

        // GET: WorkSets
        public ActionResult Index()
        {
            var workSets = db.WorkSets.Include(w => w.Team);
            return View(workSets.ToList());
        }

        // GET: WorkSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkSet workSet = db.WorkSets.Find(id);
            if (workSet == null)
            {
                return HttpNotFound();
            }
            return View(workSet);
        }

        // GET: WorkSets/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.Teams, "TeamID", "TeamName");
            return View();
        }

        // POST: WorkSets/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkSetID,WorkSetName,WorkSetValue,TeamId")] WorkSet workSet)
        {
            if (ModelState.IsValid)
            {
                db.WorkSets.Add(workSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(db.Teams, "TeamID", "TeamName", workSet.TeamId);
            return View(workSet);
        }

        // GET: WorkSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkSet workSet = db.WorkSets.Find(id);
            if (workSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.Teams, "TeamID", "TeamName", workSet.TeamId);
            return View(workSet);
        }

        // POST: WorkSets/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkSetID,WorkSetName,WorkSetValue,TeamId")] WorkSet workSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(db.Teams, "TeamID", "TeamName", workSet.TeamId);
            return View(workSet);
        }

        // GET: WorkSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkSet workSet = db.WorkSets.Find(id);
            if (workSet == null)
            {
                return HttpNotFound();
            }
            return View(workSet);
        }

        // POST: WorkSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkSet workSet = db.WorkSets.Find(id);
            db.WorkSets.Remove(workSet);
            db.SaveChanges();
            return RedirectToAction("Index");
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
