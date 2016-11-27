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
    public class ОбщиеПомещенияController : Controller
    {
        private КПEntities db = new КПEntities();

        // GET: /ОбщиеПомещения/
        [Authorize]
        public ActionResult Index(int? page, string family = "")
        {
            var sotr = from m in db.ОбщиеПомещения
                       where m.НаименованиеКоридоры.StartsWith(family)
                       select m;

            int pagesize = 10;
            int pageNumber = (page ?? 1);
            var substations = sotr.OrderBy(a => a.IDОбщПомещения);


            return View(substations.ToPagedList(pageNumber, pagesize));
        }

        // GET: /ОбщиеПомещения/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ОбщиеПомещения общиепомещения = db.ОбщиеПомещения.Find(id);
            if (общиепомещения == null)
            {
                return HttpNotFound();
            }
            return View(общиепомещения);
        }

        // GET: /ОбщиеПомещения/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDЗдания = new SelectList(db.Здания, "IDЗдания", "Наименование");
            return View();
        }

        // POST: /ОбщиеПомещения/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="НаименованиеКоридоры,Туалеты,Этаж,IDЗдания,IDОбщПомещения")] ОбщиеПомещения общиепомещения)
        {
            if (ModelState.IsValid)
            {
                db.ОбщиеПомещения.Add(общиепомещения);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDЗдания = new SelectList(db.Здания, "IDЗдания", "Наименование", общиепомещения.IDЗдания);
            return View(общиепомещения);
        }

        // GET: /ОбщиеПомещения/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ОбщиеПомещения общиепомещения = db.ОбщиеПомещения.Find(id);
            if (общиепомещения == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDЗдания = new SelectList(db.Здания, "IDЗдания", "Наименование", общиепомещения.IDЗдания);
            return View(общиепомещения);
        }

        // POST: /ОбщиеПомещения/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="НаименованиеКоридоры,Туалеты,Этаж,IDЗдания,IDОбщПомещения")] ОбщиеПомещения общиепомещения)
        {
            if (ModelState.IsValid)
            {
                db.Entry(общиепомещения).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDЗдания = new SelectList(db.Здания, "IDЗдания", "Наименование", общиепомещения.IDЗдания);
            return View(общиепомещения);
        }

        // GET: /ОбщиеПомещения/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ОбщиеПомещения общиепомещения = db.ОбщиеПомещения.Find(id);
            if (общиепомещения == null)
            {
                return HttpNotFound();
            }
            return View(общиепомещения);
        }

        // POST: /ОбщиеПомещения/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ОбщиеПомещения общиепомещения = db.ОбщиеПомещения.Find(id);
            db.ОбщиеПомещения.Remove(общиепомещения);
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
