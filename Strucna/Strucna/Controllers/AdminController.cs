using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Strucna.Baza_povezivanje;
using Strucna.Models;

namespace Strucna.Controllers
{
    public class AdminController : Controller
    {
        private strucnapraksa baza = new strucnapraksa();
        // GET: Admin
        public ActionResult index_admin()
        {
            return View();
        }
        public ActionResult logout()
        {
            Session["UserID"] = null;
            Session["Username"] = null;
            return RedirectToAction("login", "Login");
        }

        public ActionResult popis_studijskih_programa()
        {
            return View();
        }
        public ActionResult strucna_praksa()
        {
            return View();
        }

    

        public ActionResult o_praksi()
        {
            List<Student> lista = new List<Student>();
            lista = baza.Studenti.ToList();
            return View(lista);
        }

  

        public ActionResult dokumenti()
        {
            return View();
        }

        public ActionResult poduzeca()
        {
            return View();
        }

        public ActionResult prijava_studenta()
        {
            return View();
        }

    }
}