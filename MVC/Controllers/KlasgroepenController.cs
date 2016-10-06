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
    [HandleError]
    public class KlasgroepenController : Controller
    {
        private dbSchoolEntities db = new dbSchoolEntities();

        // GET: Klasgroepen
        public ActionResult Index()
        {
            var tblKlasgroeps = db.tblKlasgroeps.Include(t => t.tblDocent).Include(t => t.tblRichting);
            return View(tblKlasgroeps.ToList());
        }

        // GET: Klasgroepen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKlasgroep tblKlasgroep = db.tblKlasgroeps.Find(id);
            if (tblKlasgroep == null)
            {
                return HttpNotFound();
            }
            return View(tblKlasgroep);
        }

        // GET: Klasgroepen/Create
        public ActionResult Create()
        {
            ViewBag.docent_id = new SelectList(db.tblDocents, "docent_id", "voornaam");
            ViewBag.richting_id = new SelectList(db.tblRichtings, "richting_id", "naam");
            return View();
        }

        // POST: Klasgroepen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "klasgroep_id,naam,klascode,richting_id,docent_id")] tblKlasgroep tblKlasgroep)
        {
            if (ModelState.IsValid)
            {
                db.tblKlasgroeps.Add(tblKlasgroep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.docent_id = new SelectList(db.tblDocents, "docent_id", "voornaam", tblKlasgroep.docent_id);
            ViewBag.richting_id = new SelectList(db.tblRichtings, "richting_id", "naam", tblKlasgroep.richting_id);
            return View(tblKlasgroep);
        }

        // GET: Klasgroepen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKlasgroep tblKlasgroep = db.tblKlasgroeps.Find(id);
            if (tblKlasgroep == null)
            {
                return HttpNotFound();
            }
            ViewBag.docent_id = new SelectList(db.tblDocents, "docent_id", "voornaam", tblKlasgroep.docent_id);
            ViewBag.richting_id = new SelectList(db.tblRichtings, "richting_id", "naam", tblKlasgroep.richting_id);
            return View(tblKlasgroep);
        }

        // POST: Klasgroepen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "klasgroep_id,naam,klascode,richting_id,docent_id")] tblKlasgroep tblKlasgroep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblKlasgroep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.docent_id = new SelectList(db.tblDocents, "docent_id", "voornaam", tblKlasgroep.docent_id);
            ViewBag.richting_id = new SelectList(db.tblRichtings, "richting_id", "naam", tblKlasgroep.richting_id);
            return View(tblKlasgroep);
        }

        // GET: Klasgroepen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKlasgroep tblKlasgroep = db.tblKlasgroeps.Find(id);
            if (tblKlasgroep == null)
            {
                return HttpNotFound();
            }
            return View(tblKlasgroep);
        }

        // POST: Klasgroepen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tblKlasgroep tblKlasgroep = db.tblKlasgroeps.Find(id);
                db.tblKlasgroeps.Remove(tblKlasgroep);
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
