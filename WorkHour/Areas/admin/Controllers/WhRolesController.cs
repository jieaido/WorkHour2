using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Model;
using WorkHour.code;
using WorkHour.Models;

namespace WorkHour.Areas.admin.Controllers
{
    public class WhRolesController : Guolv
    {
        private WHDB db = new WHDB();

        // GET: WhRoles
        public ActionResult Index()
        {
            return View(db.WhRoles.ToList());
        }

        // GET: WhRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhRole whRole = db.WhRoles.Find(id);
            if (whRole == null)
            {
                return HttpNotFound();
            }
            return View(whRole);
        }

        // GET: WhRoles/Create
        public ActionResult Create()
        {
            var s = db.Permissions.ToList();
            ViewBag.Permiss = s;
            return View();
        }

        // POST: WhRoles/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Rolename,string[] permission)
        {


          
            if (ModelState.IsValid)
            {
                var s = new WhRole()
                {
                    RoleName = Rolename
                };
               
                foreach (string VARIABLE in permission)
                {
                    var id = int.Parse(VARIABLE);
                    var p= db.Permissions.FirstOrDefault(x => x.PermissionId == id);
                    s.Permissions.Add(p);  
                }
               
               
                db.WhRoles.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: WhRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhRole whRole = db.WhRoles.Find(id);
            if (whRole == null)
            {
                return HttpNotFound();
            }
            var s = db.Permissions.ToList();
            ViewBag.Permiss = s;
            return View(whRole);
        }

        // POST: WhRoles/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WhRoleId,RoleName")] WhRole whRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(whRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(whRole);
        }

        // GET: WhRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhRole whRole = db.WhRoles.Find(id);
            if (whRole == null)
            {
                return HttpNotFound();
            }
            return View(whRole);
        }

        // POST: WhRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WhRole whRole = db.WhRoles.Find(id);
            db.WhRoles.Remove(whRole);
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
