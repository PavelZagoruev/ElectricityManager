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
    public class АрендодательController : Controller
    {
        private КПEntities db = new КПEntities();

        // GET: /Арендодатель/
        [Authorize]
        public ActionResult Index(int? page, string family = "")
        {
            var sotr = from m in db.Арендодатель
                       where m.Наименование.StartsWith(family)
                       select m;

            int pagesize = 10;
            int pageNumber = (page ?? 1);
            var substations = sotr.OrderBy(a => a.IDАрендодатель);


            return View(substations.ToPagedList(pageNumber, pagesize));
        }

        // GET: /Арендодатель/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Арендодатель арендодатель = db.Арендодатель.Find(id);
            if (арендодатель == null)
            {
                return HttpNotFound();
            }
            return View(арендодатель);
        }

        // GET: /Арендодатель/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDДоговор = new SelectList(db.Договор, "IDДоговор", "ИнформацияПоПомещению");
            ViewBag.IDЗдания = new SelectList(db.Здания, "IDЗдания", "Наименование");
            ViewBag.IDСотрудника = new SelectList(db.Сотрудники, "IDСотрудника", "Фамилия");
            return View();
        }

        // POST: /Арендодатель/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Наименование,ПочтовыеДанные,IDПомещения,IDЗдания,IDСотрудника,IDДоговор,IDАрендодатель")] Арендодатель арендодатель)
        {
            if (ModelState.IsValid)
            {
                db.Арендодатель.Add(арендодатель);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDДоговор = new SelectList(db.Договор, "IDДоговор", "ИнформацияПоПомещению", арендодатель.IDДоговор);
            ViewBag.IDЗдания = new SelectList(db.Здания, "IDЗдания", "Наименование", арендодатель.IDЗдания);
            ViewBag.IDСотрудника = new SelectList(db.Сотрудники, "IDСотрудника", "Фамилия", арендодатель.IDСотрудника);
            return View(арендодатель);
        }

        // GET: /Арендодатель/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Арендодатель арендодатель = db.Арендодатель.Find(id);
            if (арендодатель == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDДоговор = new SelectList(db.Договор, "IDДоговор", "ИнформацияПоПомещению", арендодатель.IDДоговор);
            ViewBag.IDЗдания = new SelectList(db.Здания, "IDЗдания", "Наименование", арендодатель.IDЗдания);
            ViewBag.IDСотрудника = new SelectList(db.Сотрудники, "IDСотрудника", "Фамилия", арендодатель.IDСотрудника);
            return View(арендодатель);
        }

        // POST: /Арендодатель/Edit/
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Наименование,ПочтовыеДанные,IDПомещения,IDЗдания,IDСотрудника,IDДоговор,IDАрендодатель")] Арендодатель арендодатель)
        {
            if (ModelState.IsValid)
            {
                db.Entry(арендодатель).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDДоговор = new SelectList(db.Договор, "IDДоговор", "ИнформацияПоПомещению", арендодатель.IDДоговор);
            ViewBag.IDЗдания = new SelectList(db.Здания, "IDЗдания", "Наименование", арендодатель.IDЗдания);
            ViewBag.IDСотрудника = new SelectList(db.Сотрудники, "IDСотрудника", "Фамилия", арендодатель.IDСотрудника);
            return View(арендодатель);
        }

        // GET: /Арендодатель/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Арендодатель арендодатель = db.Арендодатель.Find(id);
            if (арендодатель == null)
            {
                return HttpNotFound();
            }
            return View(арендодатель);
        }

        // POST: /Арендодатель/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Арендодатель арендодатель = db.Арендодатель.Find(id);
            db.Арендодатель.Remove(арендодатель);
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
