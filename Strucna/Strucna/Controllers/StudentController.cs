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
                    if (poduzece.id_poduzece == praksa.id_student)
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

            int broj = (int)Session["UserID"];
            Student studentToUpdate = baza.Studenti.SingleOrDefault(b => b.id_studnet == broj);
            studentToUpdate.ime_prezime = s.ime_prezime;
            studentToUpdate.adresa = s.adresa;
            studentToUpdate.mob = s.mob;


            baza.SaveChanges();

            return RedirectToAction("osobni_podaci");
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

            int broj = (int)Session["dnevnikID"];
            Dnevnik_prakse dnevnikPrakseToUpdate = baza.Dnevnik.SingleOrDefault(dp => dp.id_dnevnik == broj);

            dnevnikPrakseToUpdate.red_broj = d.red_broj;
            dnevnikPrakseToUpdate.naslov = d.naslov;
            dnevnikPrakseToUpdate.opis = d.opis;




            baza.SaveChanges();

            return RedirectToAction("dnevnik_prakse");
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
    }
}