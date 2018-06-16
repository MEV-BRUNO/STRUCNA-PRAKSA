using Strucna.Baza_povezivanje;
using Strucna.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Strucna.Controllers
{
    public class LoginController : Controller
    {
        private strucnapraksa baza = new strucnapraksa();

        public ActionResult lozinka()
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
                if (m.lozinka != m.ConfirmLozinka)
                {
                    ViewBag.lozinka = "Lozinke se ne podudaraju";

                    return View(m);


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

        public ActionResult reg_student(Student s)
        {
            if (ModelState.IsValid)
            {
                foreach (Student stud in baza.Studenti)
                {
                    if (s.email == stud.email)
                    {


                        ViewBag.email = "Email se vec koristi";

                        return View(s);
                    }
                }

                if (s.lozinka != s.ConfirmLozinka)
                {
                    ViewBag.lozinka = "Lozinke se ne podudaraju";

                    return View(s);


                }

                MailMessage sendEmail = new MailMessage("info@strucnapraksa.com",s.email);
                Guid guid = Guid.NewGuid();
                sendEmail.Subject = "Welcome";
                string activation = " strucnapraksa.com/Login/Verifikacija/" + guid; 
                sendEmail.Body = "Activation link: strucnapraksa.com/Login/Verifikacija/" + guid;
                s.aktivacijski_link = activation;
                s.aktivan = 0;
                baza.Studenti.Add(s); 
                baza.SaveChanges();
               
                return RedirectToAction("login");

            }
             

               

            

            return View(s);
        }

        public ActionResult Verifikacija(string id)
        {
            ViewBag.aktivni = "Account nije aktivan";
            string activation = " strucnapraksa.com/Login/Verifikacija/" + id;
            Student student_to_update = baza.Studenti.SingleOrDefault(s => s.aktivacijski_link == activation);
            if (student_to_update.aktivan == 0)
            {

                student_to_update.aktivan = (byte)1;
                ViewBag.aktivni = "Account je aktivan";


            }


            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                baza.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return View();
        }

        [HttpGet]
        public ActionResult login()
        {
            Login obj = new Login();

            return View(obj);
        }

        [HttpPost]

        public ActionResult login(Login obj)
        {
           
            foreach (Mentor men in baza.Mentori)
            {
                
                if (men.lozinka == obj.lozinka && men.email == obj.email)
                {
                    Session["UserID"] = men.id_mentor;
                    Session["Username"] = men.ime_prezime;
                    return RedirectToAction("index_admin", "Admin");
                }
            }
            foreach (Student stud in baza.Studenti)
            {

                if (stud.lozinka == obj.lozinka && stud.email == obj.email && stud.aktivan == 1)
                {
                    // SELECT * FROM student WHERE id_student == SESSION[]
                    Session["UserID"] = stud.id_studnet;
                    Session["Username"] = stud.ime_prezime;
                    Session["Smjer"] = stud.id_studij;
                    return RedirectToAction("index_student", "Student");
                }
            }

            return RedirectToAction("login");
        }
    }
}
// ASD