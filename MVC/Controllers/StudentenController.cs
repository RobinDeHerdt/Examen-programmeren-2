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
    public class StudentenController : Controller
    {
        private dbSchoolEntities db = new dbSchoolEntities();

        // GET: Studenten
        public ActionResult Index()
        {
            var tblStudents = db.tblStudents.Include(t => t.tblKlasgroep);
            return View(tblStudents.ToList());
        }

        // GET: Studenten/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            return View(tblStudent);
        }

        // GET: Studenten/Create
        public ActionResult Create()
        {
            ViewBag.klasgroep_id = new SelectList(db.tblKlasgroeps, "klasgroep_id", "naam");
            return View();
        }

        // POST: Studenten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "student_id,voornaam,achternaam,email_ouder,rapport_wiskunde,rapport_frans,rapport_engels,rapport_sport,rapport_biologie,klasgroep_id")] tblStudent tblStudent)
        {
            if (ModelState.IsValid)
            {
                db.tblStudents.Add(tblStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.klasgroep_id = new SelectList(db.tblKlasgroeps, "klasgroep_id", "naam", tblStudent.klasgroep_id);
            return View(tblStudent);
        }

        // GET: Studenten/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.klasgroep_id = new SelectList(db.tblKlasgroeps, "klasgroep_id", "naam", tblStudent.klasgroep_id);
            return View(tblStudent);
        }

        // POST: Studenten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "student_id,voornaam,achternaam,email_ouder,rapport_wiskunde,rapport_frans,rapport_engels,rapport_sport,rapport_biologie,klasgroep_id")] tblStudent tblStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.klasgroep_id = new SelectList(db.tblKlasgroeps, "klasgroep_id", "naam", tblStudent.klasgroep_id);
            return View(tblStudent);
        }

        // GET: Studenten/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            return View(tblStudent);
        }

        // POST: Studenten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tblStudent tblStudent = db.tblStudents.Find(id);
                db.tblStudents.Remove(tblStudent);
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
