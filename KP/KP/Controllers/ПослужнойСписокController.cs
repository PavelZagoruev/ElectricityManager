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
    public class ПослужнойСписокController : Controller
    {
        private КПEntities db = new КПEntities();

        // GET: /ПослужнойСписок/
        [Authorize]
        public ActionResult Index(int? page, string family = "")
        {
            var sotr = from m in db.ПослужнойСписок
                       where m.КраткаяХарактеристика.StartsWith(family)
                       select m;

            int pagesize = 10;
            int pageNumber = (page ?? 1);
            var substations = sotr.OrderBy(a => a.IDПослужногоСписка);
            //var послужнойсписок = db.ПослужнойСписок.Include(п => п.Должности).Include(п => п.Сотрудники);

            return View(substations.ToPagedList(pageNumber, pagesize));
        } 

        // GET: /ПослужнойСписок/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ПослужнойСписок послужнойсписок = db.ПослужнойСписок.Find(id);
            if (послужнойсписок == null)
            {
                return HttpNotFound();
            }
            return View(послужнойсписок);
        }

        // GET: /ПослужнойСписок/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDДолжности = new SelectList(db.Должности, "IDДолжности", "НаименованиеДолжности");
            ViewBag.IDСотрудника = new SelectList(db.Сотрудники, "IDСотрудника", "Фамилия");
            return View();
        }

        // POST: /ПослужнойСписок/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ДатаЗанятияДолжности,КраткаяХарактеристика,IDПослужногоСписка,IDДолжности,IDСотрудника")] ПослужнойСписок послужнойсписок)
        {
            if (ModelState.IsValid)
            {
                db.ПослужнойСписок.Add(послужнойсписок);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDДолжности = new SelectList(db.Должности, "IDДолжности", "НаименованиеДолжности", послужнойсписок.IDДолжности);
            ViewBag.IDСотрудника = new SelectList(db.Сотрудники, "IDСотрудника", "Фамилия", послужнойсписок.IDСотрудника);
            return View(послужнойсписок);
        }

        // GET: /ПослужнойСписок/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ПослужнойСписок послужнойсписок = db.ПослужнойСписок.Find(id);
            if (послужнойсписок == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDДолжности = new SelectList(db.Должности, "IDДолжности", "НаименованиеДолжности", послужнойсписок.IDДолжности);
            ViewBag.IDСотрудника = new SelectList(db.Сотрудники, "IDСотрудника", "Фамилия", послужнойсписок.IDСотрудника);
            return View(послужнойсписок);
        }

        // POST: /ПослужнойСписок/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ДатаЗанятияДолжности,КраткаяХарактеристика,IDПослужногоСписка,IDДолжности,IDСотрудника")] ПослужнойСписок послужнойсписок)
        {
            if (ModelState.IsValid)
            {
                db.Entry(послужнойсписок).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDДолжности = new SelectList(db.Должности, "IDДолжности", "НаименованиеДолжности", послужнойсписок.IDДолжности);
            ViewBag.IDСотрудника = new SelectList(db.Сотрудники, "IDСотрудника", "Фамилия", послужнойсписок.IDСотрудника);
            return View(послужнойсписок);
        }

        // GET: /ПослужнойСписок/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ПослужнойСписок послужнойсписок = db.ПослужнойСписок.Find(id);
            if (послужнойсписок == null)
            {
                return HttpNotFound();
            }
            return View(послужнойсписок);
        }

        // POST: /ПослужнойСписок/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ПослужнойСписок послужнойсписок = db.ПослужнойСписок.Find(id);
            db.ПослужнойСписок.Remove(послужнойсписок);
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
