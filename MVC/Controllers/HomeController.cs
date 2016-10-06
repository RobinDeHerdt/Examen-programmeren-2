using HHS_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HHS_MVC.Controllers
{
    public class HomeController : Controller
    {
        private dbSchoolEntities db = new dbSchoolEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Aarzel niet ons te contacteren";

            return View();
        }

        public ActionResult Richtingen()
        {
            return View(db.tblRichtings.ToList());
        }

        public ActionResult Docenten()
        {
            return View(db.tblDocents.ToList());
        }
    }
}