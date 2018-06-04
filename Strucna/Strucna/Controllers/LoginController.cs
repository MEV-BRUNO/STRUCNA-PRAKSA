using Strucna.Baza_povezivanje;
using Strucna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Strucna.Controllers
{
    public class LoginController : Controller
    {
        private strucnapraksa baza = new strucnapraksa();

        public ActionResult lozinka()
        {
           

            return View();
        }


        public ActionResult AdminIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult reg_mentor()
        {
            Mentor m = new Mentor();

            return View(m);
        }

        public ActionResult reg_mentor( Mentor m)
        {
            if (ModelState.IsValid)
            {
                foreach (Mentor mentor in baza.Mentori)
                {
                    if (m.email == mentor.email)
                    {
                       

                        ViewBag.email = "Email se vec koristi";

                        return View(m);
                    }
                }
                baza.Mentori.Add(m);
                baza.SaveChanges();
                return RedirectToAction("login");

            }

            return View(m);
        }

        [HttpGet]
        public ActionResult reg_student()
        {
            Student s = new Student();

            return View(s);
        }

        [HttpGet]
        public ActionResult login()
        {
            Mentor men = new Mentor();

            return View(men);
        }

        [HttpPost]

        public ActionResult login(Mentor m)
        {
            foreach (Mentor men in baza.Mentori)
            {
                if (men.lozinka == m.lozinka && men.email == m.email)
                {
                    return RedirectToAction("AdminIndex");
                }
            }
            return RedirectToAction("login");
        }
    }
}
// ASD