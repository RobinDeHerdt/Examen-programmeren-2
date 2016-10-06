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
    public class RichtingenController : Controller
    {
        private dbSchoolEntities db = new dbSchoolEntities();

        // GET: Richtingen
        public ActionResult Index()
        {
            return View(db.tblRichtings.ToList());
        }

        // GET: Richtingen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRichting tblRichting = db.tblRichtings.Find(id);
            if (tblRichting == null)
            {
                return HttpNotFound();
            }
            return View(tblRichting);
        }

        // GET: Richtingen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Richtingen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "richting_id,naam,omschrijving")] tblRichting tblRichting)
        {
            if (ModelState.IsValid)
            {
                db.tblRichtings.Add(tblRichting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblRichting);
        }

        // GET: Richtingen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRichting tblRichting = db.tblRichtings.Find(id);
            if (tblRichting == null)
            {
                return HttpNotFound();
            }
            return View(tblRichting);
        }

        // POST: Richtingen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "richting_id,naam,omschrijving")] tblRichting tblRichting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRichting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblRichting);
        }

        // GET: Richtingen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRichting tblRichting = db.tblRichtings.Find(id);
            if (tblRichting == null)
            {
                return HttpNotFound();
            }
            return View(tblRichting);
        }

        // POST: Richtingen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tblRichting tblRichting = db.tblRichtings.Find(id);
                db.tblRichtings.Remove(tblRichting);
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
