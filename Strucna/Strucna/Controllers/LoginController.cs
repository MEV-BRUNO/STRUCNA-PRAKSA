using Strucna.Baza_povezivanje;
using Strucna.Models;
using System;
using System.Collections.Generic;
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
            foreach (Student student in baza.Studenti)
            {
                
                if (activation == student.aktivacijski_link)
                {
                    student.aktivan = 1;

                    ViewBag.aktivni = "Account je aktivan";
                    
                }
                else
                {
                    //Pogresan Guid ili je vec verifian
                }
            }

            baza.SaveChanges();
         
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
                    return RedirectToAction("index_admin", "Admin");
                }
            }
            foreach (Student stud in baza.Studenti)
            {

                if (stud.lozinka == obj.lozinka && stud.email == obj.email && stud.aktivan == 1)
                {
                    return RedirectToAction("index_admin", "Student");
                }
            }

            return RedirectToAction("login");
        }
       
    }
}
// ASD