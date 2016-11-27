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
    public class АрендаторController : Controller
    {
        private КПEntities db = new КПEntities();

        // GET: /Арендатор/
        [Authorize]
        public ActionResult Index(int? page, string family = "")
        {
            var sotr = from m in db.Арендатор
                       where m.Фамилия.StartsWith(family)
                       select m;

            int pagesize = 10;
            int pageNumber = (page ?? 1);
            var substations = sotr.OrderBy(a => a.IDАрендатор);


            return View(substations.ToPagedList(pageNumber, pagesize));
        }

        // GET: /Арендатор/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Арендатор арендатор = db.Арендатор.Find(id);
            if (арендатор == null)
            {
                return HttpNotFound();
            }
            return View(арендатор);
        }

        // GET: /Арендатор/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDДоговор = new SelectList(db.Договор, "IDДоговор", "ИнформацияПоПомещению");
            return View();
        }

        // POST: /Арендатор/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Фамилия,Имя,Отчество,ПаспортныеДанные,IDДоговор,IDАрендатор")] Арендатор арендатор)
        {
            if (ModelState.IsValid)
            {
                db.Арендатор.Add(арендатор);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDДоговор = new SelectList(db.Договор, "IDДоговор", "ИнформацияПоПомещению", арендатор.IDДоговор);
            return View(арендатор);
        }

        // GET: /Арендатор/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Арендатор арендатор = db.Арендатор.Find(id);
            if (арендатор == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDДоговор = new SelectList(db.Договор, "IDДоговор", "ИнформацияПоПомещению", арендатор.IDДоговор);
            return View(арендатор);
        }

        // POST: /Арендатор/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Фамилия,Имя,Отчество,ПаспортныеДанные,IDДоговор,IDАрендатор")] Арендатор арендатор)
        {
            if (ModelState.IsValid)
            {
                db.Entry(арендатор).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDДоговор = new SelectList(db.Договор, "IDДоговор", "ИнформацияПоПомещению", арендатор.IDДоговор);
            return View(арендатор);
        }

        // GET: /Арендатор/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Арендатор арендатор = db.Арендатор.Find(id);
            if (арендатор == null)
            {
                return HttpNotFound();
            }
            return View(арендатор);
        }

        // POST: /Арендатор/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Арендатор арендатор = db.Арендатор.Find(id);
            db.Арендатор.Remove(арендатор);
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
