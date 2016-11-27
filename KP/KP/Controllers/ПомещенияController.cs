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
    public class ПомещенияController : Controller
    {
        private КПEntities db = new КПEntities();

        // GET: /Помещения/
        [Authorize]
        public ActionResult Index(int? page, string numm = "")
        {
            int vidR = 0;

            if (numm != "")
            {
                vidR = Convert.ToInt32(numm);
                var sotr = from m in db.Помещения
                           where m.Этаж == vidR
                           select m;

                int pagesize = 10;
                int pageNumber = (page ?? 1);
                var substations = sotr.OrderBy(a => a.IDПомещения);
                return View(substations.ToPagedList(pageNumber, pagesize));
            }
            else
            {
                var sotr = from m in db.Помещения
                           select m;

                int pagesize = 10;
                int pageNumber = (page ?? 1);
                var substations = sotr.OrderBy(a => a.IDПомещения);
                return View(substations.ToPagedList(pageNumber, pagesize));
            }
        }

        // GET: /Помещения/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Помещения помещения = db.Помещения.Find(id);
            if (помещения == null)
            {
                return HttpNotFound();
            }
            return View(помещения);
        }

        // GET: /Помещения/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDАрендодатель = new SelectList(db.Арендодатель, "IDАрендодатель", "Наименование");
            ViewBag.IDЗдания = new SelectList(db.Здания, "IDЗдания", "Наименование");
            return View();
        }

        // POST: /Помещения/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDПомещения,Площадь,Этаж,Номер,IDЗдания,IDАрендодатель")] Помещения помещения)
        {
            if (ModelState.IsValid)
            {
                db.Помещения.Add(помещения);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDАрендодатель = new SelectList(db.Арендодатель, "IDАрендодатель", "Наименование", помещения.IDАрендодатель);
            ViewBag.IDЗдания = new SelectList(db.Здания, "IDЗдания", "Наименование", помещения.IDЗдания);
            return View(помещения);
        }

        // GET: /Помещения/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Помещения помещения = db.Помещения.Find(id);
            if (помещения == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDАрендодатель = new SelectList(db.Арендодатель, "IDАрендодатель", "Наименование", помещения.IDАрендодатель);
            ViewBag.IDЗдания = new SelectList(db.Здания, "IDЗдания", "Наименование", помещения.IDЗдания);
            return View(помещения);
        }

        // POST: /Помещения/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDПомещения,Площадь,Этаж,Номер,IDЗдания,IDАрендодатель")] Помещения помещения)
        {
            if (ModelState.IsValid)
            {
                db.Entry(помещения).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDАрендодатель = new SelectList(db.Арендодатель, "IDАрендодатель", "Наименование", помещения.IDАрендодатель);
            ViewBag.IDЗдания = new SelectList(db.Здания, "IDЗдания", "Наименование", помещения.IDЗдания);
            return View(помещения);
        }

        // GET: /Помещения/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Помещения помещения = db.Помещения.Find(id);
            if (помещения == null)
            {
                return HttpNotFound();
            }
            return View(помещения);
        }

        // POST: /Помещения/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Помещения помещения = db.Помещения.Find(id);
            db.Помещения.Remove(помещения);
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
