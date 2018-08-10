using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

        public FileResult Download(int id)
        {
            Dokumenti dok = baza.Dokument.SingleOrDefault(s => s.id_dokument == id);

            byte[] fileBytes = System.IO.File.ReadAllBytes(dok.put);
            string fileName = dok.naziv;
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult index_student()
        {
            List<VratiStudente> lista = new List<VratiStudente>();
            List<Student> listaStudenata = baza.Studenti.ToList();
            List<Poduzece> listaSPoduzeca = baza.Poduzeca.ToList();
            foreach (Praksa_student praksa in baza.PraksaStudent)
            {
                VratiStudente a = new VratiStudente();

                a.datoum_od = praksa.datum_od.ToString();
                a.datoum_do = praksa.datum_do.ToString();
                if (praksa.odobreno == 0)
                {
                    a.odobreno = "Ne";
                }
                else
                {
                    a.odobreno = "Da";
                }

                if (praksa.ocjena == 0)
                {
                    a.ocjena = "Neocjenjeno";
                }
                else if (praksa.ocjena == 1)
                {
                    a.ocjena = "Pozitivno";
                }
                else
                {
                    a.ocjena = "Negativno";
                }

                foreach (Student student in listaStudenata)
                {
                    if (student.id_studnet == praksa.id_student)
                    {
                        a.id_student = student.id_studnet;
                        a.ime = student.ime_prezime;


                    }
                }

                foreach (Poduzece poduzece in listaSPoduzeca)
                {
                    if (poduzece.id_poduzece == praksa.id_poduzece)
                    {

                        a.poduzece = poduzece.naziv;


                    }
                }


                lista.Add(a);

            }


            return View(lista);

        }

        public ActionResult logout()
        {
            Session["UserID"] = null;
            Session["Username"] = null;
            return RedirectToAction("login", "Login");
        }

        public ActionResult dnevnik_prakse()
        {
            List<Dnevnik_prakse> lista = new List<Dnevnik_prakse>();
            foreach (Dnevnik_prakse dok in baza.Dnevnik)
            {

                lista.Add(dok);

            }

            return View(lista);
        }

        public ActionResult osobni_podaci()
        {
            List<Student> lista = baza.Studenti.ToList();
            return View(lista);

        }

        public ActionResult dokumenti()
        {
            List<Dokumenti> lista = baza.Dokument.ToList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult prijava_prakse()
        {
            Praksa_student p = new Praksa_student();

            return View(p);
        }

        [HttpPost]
        public ActionResult prijava_prakse(Praksa_student p)
        {
            int broj = (int) Session["UserID"];

            foreach (Praksa_student praksa in baza.PraksaStudent)
            {
                if (praksa.id_student == broj)
                {
                    ViewBag.samojedna = "Mozete imati prijavljenu samo jednu prasku.";
                    return View();
                }
            }

            Praksa datum = baza.Prakse.SingleOrDefault(s => s.id_praksa == p.id_praksa);


            p.id_student = broj;
            p.datum_do = datum.datum_do;
            p.datum_od = datum.datum_od;

            if (ModelState.IsValid)
            {

                baza.PraksaStudent.Add(p);
                baza.SaveChanges();

                return RedirectToAction("index_student");
            }
            else
            {
                throw new ArgumentException();
            }


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

            List<Praksa> listaPrkse = baza.Prakse.ToList();

            if (ModelState.IsValid)
            {

                baza.Poduzeca.Add(p);
                baza.SaveChanges();

                return RedirectToAction("index_student");
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

            foreach (Student student in baza.Studenti)
            {
                if (student.id_studnet == broj)
                {
                    student.ime_prezime = s.ime_prezime;
                    student.adresa = s.adresa;
                    student.mob = s.mob;
                    s.lozinka = student.lozinka;


                }
            }

            ModelState["lozinka"].Errors.Clear();

            if (ModelState.IsValid)
            {
                baza.SaveChanges();
                return RedirectToAction("osobni_podaci");
            }


            return View();

        }



        [HttpGet]
        public ActionResult EditDnevnik(int id)
        {
            Dnevnik_prakse dnevnikPrakseToUpdate = baza.Dnevnik.SingleOrDefault(dp => dp.id_dnevnik == id);
            Session["dnevnikID"] = id;
            return View(dnevnikPrakseToUpdate);

        }

        [HttpPost]
        public ActionResult EditDnevnik(Dnevnik_prakse d)
        {

            int broj = (int) Session["dnevnikID"];
            Dnevnik_prakse dnevnikPrakseToUpdate = baza.Dnevnik.SingleOrDefault(dp => dp.id_dnevnik == broj);

            dnevnikPrakseToUpdate.red_broj = d.red_broj;
            dnevnikPrakseToUpdate.naslov = d.naslov;
            dnevnikPrakseToUpdate.opis = d.opis;


            if (ModelState.IsValid)
            {
                
            

            baza.SaveChanges();

            return RedirectToAction("dnevnik_prakse");
            }

            return View();
        }




        [HttpGet]
        public ActionResult NoviDnevnik()
        {


            return View();
        }

        [HttpPost]
        public ActionResult NoviDnevnik(Dnevnik_prakse dp)
        {

            Dnevnik_prakse dpObj = new Dnevnik_prakse();
            int broj = (int) Session["UserID"];


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

            if (ModelState.IsValid)
            {
                
          
            baza.Dnevnik.Add(dpObj);

            baza.SaveChanges();


            return RedirectToAction("dnevnik_prakse");
            }

            return View();


        }

        [HttpGet]
        public ActionResult cheangePassword(int id)
        {

            Student studentToUpdate = baza.Studenti.SingleOrDefault(s => s.id_studnet == id);
            return View(studentToUpdate);
        }

        [HttpPost]
        public ActionResult cheangePassword(Student s)
        {
            int broj = (int) Session["UserID"];

            foreach (Student student in baza.Studenti)
            {
                if (student.id_studnet == broj)
                {
                    if (s.lozinka == null || s.ConfirmLozinka == null)
                    {
                        ViewBag.lozinka = "Lozinka je obavezan podatak";
                        return View();
                    }
                    
                    if (s.lozinka != s.ConfirmLozinka)
                    {
                        ViewBag.lozinka = "Lozinke nisu iste.";
                        return View();
                    }

                    student.lozinka = s.lozinka;



                }
            }

            
                baza.SaveChanges();
                return RedirectToAction("osobni_podaci");
           
        }
    }


}