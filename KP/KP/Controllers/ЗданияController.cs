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
    public class ЗданияController : Controller
    {
        private КПEntities db = new КПEntities();

        // GET: /Здания/
        [Authorize]
        public ActionResult Index(int? page, string family = "")
        {
            var sotr = from m in db.Здания
                       where m.Наименование.StartsWith(family)
                       select m;

            int pagesize = 10;
            int pageNumber = (page ?? 1);
            var substations = sotr.OrderBy(a => a.IDЗдания);


            return View(substations.ToPagedList(pageNumber, pagesize));
        }

        // GET: /Здания/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Здания здания = db.Здания.Find(id);
            if (здания == null)
            {
                return HttpNotFound();
            }
            return View(здания);
        }

        // GET: /Здания/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Здания/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Наименование,Этажность,ПочтовыеДанные,НомерПомещения,IDЗдания")] Здания здания)
        {
            if (ModelState.IsValid)
            {
                db.Здания.Add(здания);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(здания);
        }

        // GET: /Здания/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Здания здания = db.Здания.Find(id);
            if (здания == null)
            {
                return HttpNotFound();
            }
            return View(здания);
        }

        // POST: /Здания/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Наименование,Этажность,ПочтовыеДанные,НомерПомещения,IDЗдания")] Здания здания)
        {
            if (ModelState.IsValid)
            {
                db.Entry(здания).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(здания);
        }

        // GET: /Здания/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Здания здания = db.Здания.Find(id);
            if (здания == null)
            {
                return HttpNotFound();
            }
            return View(здания);
        }

        // POST: /Здания/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Здания здания = db.Здания.Find(id);
            db.Здания.Remove(здания);
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
