using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
        //public ActionResult Index()
        //{
        //    var workTimes = db.WorkTimes.Include(w => w.Station);
        //    return View(workTimes.ToList());
        //}

        //// GET: WorkTimes/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    WorkTime workTime = db.WorkTimes.Find(id);
        //    if (workTime == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(workTime);
        //}

        //// GET: WorkTimes/Create
        public ActionResult Create()
        {
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName");
            //todo member 要增加判断逻辑,只显示当前用户的member
            ViewBag.members = db.Members.ToList();
            return View();
        }

        //// POST: WorkTimes/Create
        //// 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        //// 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "WorkTimeID,MemberID,StationID,StartTime,EndTime,WorkProgram,Remarks,WorkTimeValue,SubTime,SubMemberID,isDel")] WorkTime workTime)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.WorkTimes.Add(workTime);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        [HttpPost]
        public ActionResult Create(WorkTime workTime)
        {
            //todo 逻辑没有做啊

            return Content("ok");
        }

        //    ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", workTime.StationID);
        //    return View(workTime);
        //}

        //// GET: WorkTimes/Edit/5
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

        //// POST: WorkTimes/Edit/5
        //// 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        //// 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
 
        public ActionResult Edit([Bind(Include = "WorkTimeID,MemberID,StationID,StartTime,EndTime,WorkProgram,Remarks,WorkTimeValue")] WorkTime workTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("table");
            }
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", workTime.StationID);
            return View(workTime);
        }

        //// GET: WorkTimes/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    WorkTime workTime = db.WorkTimes.Find(id);
        //    if (workTime == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(workTime);
        //}

        //// POST: WorkTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //todo    [ValidateAntiForgeryToken]这个东西会报错,回来查一下

            WorkTime workTime = db.WorkTimes.Find(id);
            db.WorkTimes.Remove(workTime);
            db.SaveChanges();
            return RedirectToAction("table");
        }

        public ActionResult InitTable(int rows,int page)
        {

            //     public virtual IQueryable<T> Pages<Tkey>(int pageSize, int pageIndex, out int Count, Func<T, bool> wherelambda,
            //    Func<T, Tkey> orderlambda)
            //{
            //    Count = Oadb.Set<T>().Where(wherelambda).Count();
            //    return
            //        Oadb.Set<T>().Where(wherelambda)
            //            .Take(pageSize)
            //            .Skip((pageIndex - 1) * pageIndex)
            //            .OrderBy(orderlambda)
            //            .AsQueryable();
            //上面那段话可以运行,因为Where(wherelambda)返回的是IEnumerable,不知道为啥.todo

            //todo 回来再查

                    var s = db.WorkTimes.
                            Where(x => x.WorkTimeID > 0).
                            Take(rows).
                            OrderBy(x => x.WorkTimeID).
                            Skip((page - 1) * rows).ToList();
            //  .AsQueryable()不行,tolist行
            //.AsQueryable()会报1:wt.StartTime.ToShortDateString() 不能在linq中使用.2:orderby要在skip前面
            //Expression<Func<WorkTime, bool>>labma = x => x.WorkTimeID > 0;
            //如果是用expression 查询的就是iqueryable,
            //用func查询就是ienumerable
            //db.WorkTimes.Where(labma
            //    ).Take(10
            //    ).Skip(
            //        2);
            
            var count = db.WorkTimes.ToList().Count;


            var result = new
            {
                total=count,
                rows = (from wt in s
                        select
                        new {
                            wt.WorkTimeID,
                          wt.Station.StationName,
                          starttime = wt.StartTime.ToLongDateString() , endtime = wt.EndTime.ToString("yyyy-M-d dddd hh:mm:ss t") ,
                          wt.WorkProgram,
                          //wt.Member.MemberName,
                          wt.WorkTimeValue,
                      }).ToList()
             }
            ;

            return Json(result);
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
