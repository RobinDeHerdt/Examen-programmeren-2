using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HHS_MVC.Models;

namespace HHS_MVC.Controllers
{
    public class DocentenController : Controller
    {
        private dbSchoolEntities db = new dbSchoolEntities();

        // GET: Docenten
        public ActionResult Index()
        {
            return View(db.tblDocents.ToList());
        }

        // GET: Docenten/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDocent tblDocent = db.tblDocents.Find(id);
            if (tblDocent == null)
            {
                return HttpNotFound();
            }
            return View(tblDocent);
        }

        // GET: Docenten/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Docenten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "docent_id,voornaam,achternaam,email")] tblDocent tblDocent)
        {
            if (ModelState.IsValid)
            {
                db.tblDocents.Add(tblDocent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDocent);
        }

        // GET: Docenten/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDocent tblDocent = db.tblDocents.Find(id);
            if (tblDocent == null)
            {
                return HttpNotFound();
            }
            return View(tblDocent);
        }

        // POST: Docenten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "docent_id,voornaam,achternaam,email")] tblDocent tblDocent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDocent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDocent);
        }

        // GET: Docenten/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDocent tblDocent = db.tblDocents.Find(id);
            if (tblDocent == null)
            {
                return HttpNotFound();
            }
            return View(tblDocent);
        }

        // POST: Docenten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            { 
                tblDocent tblDocent = db.tblDocents.Find(id);
                db.tblDocents.Remove(tblDocent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");
            }
            
        }

        public ActionResult Error()
        {
            return View();
        }

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
