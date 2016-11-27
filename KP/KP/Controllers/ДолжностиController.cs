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
    public class ДолжностиController : Controller
    {
        private КПEntities db = new КПEntities();

        // GET: /Должности/
        [Authorize]
        public ActionResult Index(int? page, string family = "")
        {
            var sotr = from m in db.Должности
                       where m.НаименованиеДолжности.StartsWith(family)
                       select m;

            int pagesize = 10;
            int pageNumber = (page ?? 1);
            var substations = sotr.OrderBy(a => a.IDДолжности);


            return View(substations.ToPagedList(pageNumber, pagesize));
        }

        // GET: /Должности/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Должности должности = db.Должности.Find(id);
            if (должности == null)
            {
                return HttpNotFound();
            }
            return View(должности);
        }

        // GET: /Должности/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Должности/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDДолжности,НаименованиеДолжности,Оклад,Требования")] Должности должности)
        {
            if (ModelState.IsValid)
            {
                db.Должности.Add(должности);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(должности);
        }

        // GET: /Должности/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Должности должности = db.Должности.Find(id);
            if (должности == null)
            {
                return HttpNotFound();
            }
            return View(должности);
        }

        // POST: /Должности/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDДолжности,НаименованиеДолжности,Оклад,Требования")] Должности должности)
        {
            if (ModelState.IsValid)
            {
                db.Entry(должности).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(должности);
        }

        // GET: /Должности/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Должности должности = db.Должности.Find(id);
            if (должности == null)
            {
                return HttpNotFound();
            }
            return View(должности);
        }

        // POST: /Должности/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Должности должности = db.Должности.Find(id);
            db.Должности.Remove(должности);
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
