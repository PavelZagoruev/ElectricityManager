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
    public class ЭлектрооборудованиеController : Controller
    {
        private КПEntities db = new КПEntities();

        // GET: /Электрооборудование/
        [Authorize]
        public ActionResult Index(int? page, string family = "")
        {
            var sotr = from m in db.Электрооборудование
                       where m.Наименование.StartsWith(family)
                       select m;

            int pagesize = 10;
            int pageNumber = (page ?? 1);
            var substations = sotr.OrderBy(a => a.IDЭлектрооборудование);


            return View(substations.ToPagedList(pageNumber, pagesize));
        }

        // GET: /Электрооборудование/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Электрооборудование электрооборудование = db.Электрооборудование.Find(id);
            if (электрооборудование == null)
            {
                return HttpNotFound();
            }
            return View(электрооборудование);
        }

        // GET: /Электрооборудование/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Электрооборудование/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Наименование,Количество,СуточноеВремяРаботы,IDЭлектрооборудование")] Электрооборудование электрооборудование)
        {
            if (ModelState.IsValid)
            {
                db.Электрооборудование.Add(электрооборудование);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(электрооборудование);
        }

        // GET: /Электрооборудование/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Электрооборудование электрооборудование = db.Электрооборудование.Find(id);
            if (электрооборудование == null)
            {
                return HttpNotFound();
            }
            return View(электрооборудование);
        }

        // POST: /Электрооборудование/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Наименование,Количество,СуточноеВремяРаботы,IDЭлектрооборудование")] Электрооборудование электрооборудование)
        {
            if (ModelState.IsValid)
            {
                db.Entry(электрооборудование).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(электрооборудование);
        }

        // GET: /Электрооборудование/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Электрооборудование электрооборудование = db.Электрооборудование.Find(id);
            if (электрооборудование == null)
            {
                return HttpNotFound();
            }
            return View(электрооборудование);
        }

        // POST: /Электрооборудование/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Электрооборудование электрооборудование = db.Электрооборудование.Find(id);
            db.Электрооборудование.Remove(электрооборудование);
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
