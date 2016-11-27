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
    public class ПоказанияСчётчикаController : Controller
    {
        private КПEntities db = new КПEntities();

        // GET: /ПоказанияСчётчика/
        [Authorize]
        public ActionResult Index(int? page, string numm = "")
        {
            int vidR = 0;

            if (numm != "")
            {
                vidR = Convert.ToInt32(numm);
                var sotr = from m in db.ПоказанияСчётчика
                           where m.Номер == vidR
                           select m;

                int pagesize = 10;
                int pageNumber = (page ?? 1);
                var substations = sotr.OrderBy(a => a.IDСотрудника);
                return View(substations.ToPagedList(pageNumber, pagesize));
            }
            else
            {
                var sotr = from m in db.ПоказанияСчётчика
                           select m;

                int pagesize = 10;
                int pageNumber = (page ?? 1);
                var substations = sotr.OrderBy(a => a.IDСотрудника);
                return View(substations.ToPagedList(pageNumber, pagesize));
            }

            //var показаниясчётчика = db.ПоказанияСчётчика.Include(п => п.Сотрудники).Include(п => п.Электрооборудование);
        }

        // GET: /ПоказанияСчётчика/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ПоказанияСчётчика показаниясчётчика = db.ПоказанияСчётчика.Find(id);
            if (показаниясчётчика == null)
            {
                return HttpNotFound();
            }
            return View(показаниясчётчика);
        }

        // GET: /ПоказанияСчётчика/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDСотрудника = new SelectList(db.Сотрудники, "IDСотрудника", "Фамилия");
            ViewBag.IDЭлектрооборудование = new SelectList(db.Электрооборудование, "IDЭлектрооборудование", "Наименование");
            return View();
        }

        // POST: /ПоказанияСчётчика/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Номер,Дата,Арендодатель,Месяц,Год,Сумма,IDЭлектрооборудование,IDСчётчика,IDСотрудника")] ПоказанияСчётчика показаниясчётчика)
        {
            if (ModelState.IsValid)
            {
                db.ПоказанияСчётчика.Add(показаниясчётчика);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDСотрудника = new SelectList(db.Сотрудники, "IDСотрудника", "Фамилия", показаниясчётчика.IDСотрудника);
            ViewBag.IDЭлектрооборудование = new SelectList(db.Электрооборудование, "IDЭлектрооборудование", "Наименование", показаниясчётчика.IDЭлектрооборудование);
            return View(показаниясчётчика);
        }

        // GET: /ПоказанияСчётчика/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ПоказанияСчётчика показаниясчётчика = db.ПоказанияСчётчика.Find(id);
            if (показаниясчётчика == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDСотрудника = new SelectList(db.Сотрудники, "IDСотрудника", "Фамилия", показаниясчётчика.IDСотрудника);
            ViewBag.IDЭлектрооборудование = new SelectList(db.Электрооборудование, "IDЭлектрооборудование", "Наименование", показаниясчётчика.IDЭлектрооборудование);
            return View(показаниясчётчика);
        }

        // POST: /ПоказанияСчётчика/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Номер,Дата,Арендодатель,Месяц,Год,Сумма,IDЭлектрооборудование,IDСчётчика,IDСотрудника")] ПоказанияСчётчика показаниясчётчика)
        {
            if (ModelState.IsValid)
            {
                db.Entry(показаниясчётчика).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDСотрудника = new SelectList(db.Сотрудники, "IDСотрудника", "Фамилия", показаниясчётчика.IDСотрудника);
            ViewBag.IDЭлектрооборудование = new SelectList(db.Электрооборудование, "IDЭлектрооборудование", "Наименование", показаниясчётчика.IDЭлектрооборудование);
            return View(показаниясчётчика);
        }

        // GET: /ПоказанияСчётчика/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ПоказанияСчётчика показаниясчётчика = db.ПоказанияСчётчика.Find(id);
            if (показаниясчётчика == null)
            {
                return HttpNotFound();
            }
            return View(показаниясчётчика);
        }

        // POST: /ПоказанияСчётчика/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ПоказанияСчётчика показаниясчётчика = db.ПоказанияСчётчика.Find(id);
            db.ПоказанияСчётчика.Remove(показаниясчётчика);
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
