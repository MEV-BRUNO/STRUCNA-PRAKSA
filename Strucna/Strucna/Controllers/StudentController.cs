using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Strucna.Baza_povezivanje;
using Strucna.Models;

namespace Strucna.Controllers
{
    public class StudentController : Controller
    {
        strucnapraksa baza = new strucnapraksa();
        public ActionResult index_student()
        {
            return View();
        }
        public ActionResult logout()
        {
            Session["UserID"] = null;
            Session["Username"] = null;
            return RedirectToAction("login", "Login");
        }

        public ActionResult dnevnik_prakse()
        {
            return View();
        }

        public ActionResult osobni_podaci()
        {
            return View();
        }

        public ActionResult dokumenti()
        {
            return View();
        }


        [HttpGet]
        public ActionResult prijava_studenta()
        {
            Poduzece p = new Poduzece();
           
            return View(p);
        }

         [HttpPost]
        public ActionResult prijava_studenta(Poduzece p)
        {

            if (ModelState.IsValid)
            {
                
            
            baza.Poduzeca.Add(p);
            baza.SaveChanges();

                return RedirectToAction("index_student");
            }
            else
            {
                throw new ArgumentException();
            }

            return View();
        }
    }
}