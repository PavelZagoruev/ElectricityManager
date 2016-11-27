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
    public class СотрудникиController : Controller
    {
        private КПEntities db = new КПEntities();

        // GET: /Сотрудники/
        [Authorize]
        public ActionResult Index(int? page, string family = "")
        {
            var sotr = from m in db.Сотрудники
                       where m.Фамилия.StartsWith(family)
                       select m;

            int pagesize = 10;
            int pageNumber = (page ?? 1);
            var substations = sotr.OrderBy(a => a.IDСотрудника);


            return View(substations.ToPagedList(pageNumber, pagesize));
        }

        // GET: /Сотрудники/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Сотрудники сотрудники = db.Сотрудники.Find(id);
            if (сотрудники == null)
            {
                return HttpNotFound();
            }
            return View(сотрудники);
        }

        // GET: /Сотрудники/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Сотрудники/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Фамилия,Имя,Отчество,Фото,ДатаРождения,Пол,Адрес,Телефон,Образование,IDСотрудника,ПаспортныеДанные")] Сотрудники сотрудники)
        {
            if (ModelState.IsValid)
            {
                db.Сотрудники.Add(сотрудники);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(сотрудники);
        }

        // GET: /Сотрудники/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Сотрудники сотрудники = db.Сотрудники.Find(id);
            if (сотрудники == null)
            {
                return HttpNotFound();
            }
            return View(сотрудники);
        }

        // POST: /Сотрудники/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Фамилия,Имя,Отчество,Фото,ДатаРождения,Пол,Адрес,Телефон,Образование,IDСотрудника,ПаспортныеДанные")] Сотрудники сотрудники)
        {
            if (ModelState.IsValid)
            {
                db.Entry(сотрудники).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(сотрудники);
        }

        // GET: /Сотрудники/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Сотрудники сотрудники = db.Сотрудники.Find(id);
            if (сотрудники == null)
            {
                return HttpNotFound();
            }
            return View(сотрудники);
        }

        // POST: /Сотрудники/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Сотрудники сотрудники = db.Сотрудники.Find(id);
            db.Сотрудники.Remove(сотрудники);
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
