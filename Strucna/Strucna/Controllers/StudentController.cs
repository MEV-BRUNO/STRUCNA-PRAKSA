using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
                Praksa_student ps = new Praksa_student();
                ps.datum_od = DateTime.Today;
                ps.datum_do = ps.datum_od.AddDays(30);
                ps.id_poduzece = p.id_poduzece;
                ps.id_student = (int) Session["UserID"];
                ps.odobreno = 0;


                baza.PraksaStudent.Add(ps);
                baza.SaveChanges();
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student studentToUpdate = baza.Studenti.SingleOrDefault(s => s.id_studnet == id);
            return View(studentToUpdate);
        }

        [HttpPost]

        public ActionResult Edit(Student s)
        {

            int broj = (int) Session["UserID"];
            Student studentToUpdate = baza.Studenti.SingleOrDefault(b => b.id_studnet == broj);
            studentToUpdate.ime_prezime = s.ime_prezime;
            studentToUpdate.adresa = s.adresa;
            studentToUpdate.mob = s.mob;


            baza.SaveChanges();

            return View(studentToUpdate);
        }

        

        [HttpGet]
        public ActionResult EditDnevnik(int id)
        {
            Dnevnik_prakse dnevnikPrakseToUpdate = baza.Dnevnik.SingleOrDefault(dp => dp.id_praksa == id);
            return View(dnevnikPrakseToUpdate);

        }

        [HttpPost]
        public ActionResult EditDnevnik(Dnevnik_prakse d)
        {

            int broj = (int) Session["UserID"];
            Dnevnik_prakse dnevnikPrakseToUpdate = baza.Dnevnik.SingleOrDefault(dp => dp.id_praksa == broj);
            dnevnikPrakseToUpdate.red_broj = d.red_broj;
            dnevnikPrakseToUpdate.datum = d.datum;
            dnevnikPrakseToUpdate.naslov = d.naslov;
            dnevnikPrakseToUpdate.opis = d.opis;




            baza.SaveChanges();

            return View(dnevnikPrakseToUpdate);
        }

        public ActionResult dnevnik_prakse()
        {
            List<Dnevnik_prakse> dnevnikk = baza.Dnevnik.ToList();
            return View(dnevnikk);
        }
        

        [HttpGet]
        public ActionResult NoviDnevnik()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("NoviDnevnik");
            }
            else

                return View("");
        }

        [HttpPost]
        public ActionResult NoviDnevnik(Dnevnik_prakse dp)
        {
            if (!ModelState.IsValid)
            {
                return View("NoviDnevnik", dp);



            }
            Dnevnik_prakse dpObj = new Dnevnik_prakse();
            int broj = (int)Session["UserID"];
            
           
            foreach (Praksa_student praksaStudent in baza.PraksaStudent)
            {
                if (praksaStudent.id_student == broj)
                {
                    dpObj.id_praksa = praksaStudent.id_praksa;
                    break;
                }
            }

            if (dpObj.id_praksa < 0)
            {
                return RedirectToAction("dnevnik_prakse");
            }

                dpObj.id_student = broj;
                dpObj.datum = dp.datum;
                dpObj.naslov = dp.naslov;
                dpObj.opis = dp.opis;
            

                baza.Dnevnik.Add(dpObj);
                baza.SaveChanges();
            

            return RedirectToAction("dnevnik_prakse");



        }

        public ActionResult DownloadFile()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "FolderName/";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "filename.extension");
            string fileName = "filename.extension";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }



    }


}   

