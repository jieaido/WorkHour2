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
    public class WorkTimesController : Controller
    {
        private WHDB db = new WHDB();

        // GET: WorkTimes
        public ActionResult Index()
        {
            var workTimes = db.WorkTimes.Include(w => w.Station);
            return View(workTimes.ToList());
        }

        // GET: WorkTimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTime workTime = db.WorkTimes.Find(id);
            if (workTime == null)
            {
                return HttpNotFound();
            }
            return View(workTime);
        }

        // GET: WorkTimes/Create
        public ActionResult Create()
        {
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName");
            return View();
        }

        // POST: WorkTimes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkTimeID,MemberID,StationID,StartTime,EndTime,WorkProgram,Remarks,WorkTimeValue,SubTime,SubMemberID,isDel")] WorkTime workTime)
        {
            if (ModelState.IsValid)
            {
                db.WorkTimes.Add(workTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", workTime.StationID);
            return View(workTime);
        }

        // GET: WorkTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTime workTime = db.WorkTimes.Find(id);
            if (workTime == null)
            {
                return HttpNotFound();
            }
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", workTime.StationID);
            return View(workTime);
        }

        // POST: WorkTimes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkTimeID,MemberID,StationID,StartTime,EndTime,WorkProgram,Remarks,WorkTimeValue,SubTime,SubMemberID,isDel")] WorkTime workTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", workTime.StationID);
            return View(workTime);
        }

        // GET: WorkTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTime workTime = db.WorkTimes.Find(id);
            if (workTime == null)
            {
                return HttpNotFound();
            }
            return View(workTime);
        }

        // POST: WorkTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkTime workTime = db.WorkTimes.Find(id);
            db.WorkTimes.Remove(workTime);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult InitTable()
        {
            var s = db.Teams.ToList();

            return Json(s);
        }

        public ActionResult table()
        {
            return View();
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
