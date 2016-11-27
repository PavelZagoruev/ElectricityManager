using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KP.Models;
using PagedList.Mvc;
using PagedList;

namespace KP.Controllers
{
    public class ДоговорController : Controller
    {
        private КПEntities db = new КПEntities();

        // GET: /Договор/
        [Authorize]
        public ActionResult Index(int? page, string family = "")
        {
            var sotr = from m in db.Договор
                       where m.ИнформацияПоПомещению.StartsWith(family)
                       select m;

            int pagesize = 10;
            int pageNumber = (page ?? 1);
            var substations = sotr.OrderBy(a => a.IDДоговор);


            return View(substations.ToPagedList(pageNumber, pagesize));
        }

        // GET: /Договор/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Договор договор = db.Договор.Find(id);
            if (договор == null)
            {
                return HttpNotFound();
            }
            return View(договор);
        }

        // GET: /Договор/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Договор/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDДоговор,ДатаВъезда,ДатаВыеда,ИнформацияПоПомещению")] Договор договор)
        {
            if (ModelState.IsValid)
            {
                db.Договор.Add(договор);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(договор);
        }

        // GET: /Договор/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Договор договор = db.Договор.Find(id);
            if (договор == null)
            {
                return HttpNotFound();
            }
            return View(договор);
        }

        // POST: /Договор/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDДоговор,ДатаВъезда,ДатаВыеда,ИнформацияПоПомещению")] Договор договор)
        {
            if (ModelState.IsValid)
            {
                db.Entry(договор).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(договор);
        }

        // GET: /Договор/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Договор договор = db.Договор.Find(id);
            if (договор == null)
            {
                return HttpNotFound();
            }
            return View(договор);
        }

        // POST: /Договор/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Договор договор = db.Договор.Find(id);
            db.Договор.Remove(договор);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
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
