﻿using System;
using System.Collections.Generic;
using System.IO;
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
            List<Studij> lista = baza.Smjerovi.ToList();
            return View(lista);
        }
        public ActionResult strucna_praksa()
        {
            return View();
        }

    

        public ActionResult o_praksi()
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

  

        public ActionResult dokumenti()
        {
            List<Dokumenti> lista = baza.Dokument.ToList();
            return View(lista);
        }
        public ActionResult noviDokument()
        {
        
            return View();
        }
        [HttpPost]
        public ActionResult noviDokument(HttpPostedFileBase postedFile)
        {
            Dokumenti d = new Dokumenti();
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
               
                d.naziv = postedFile.FileName;
                postedFile.SaveAs(path+Path.GetFileName(postedFile.FileName));

                d.put =path+postedFile.FileName;
            }

            if (d == null)
            {

                return RedirectToAction("dokumenti");

            }

            baza.Dokument.Add(d);
            baza.SaveChanges();

           return RedirectToAction("dokumenti") ;
        }

 

        public ActionResult poduzeca()
        {
            List<Poduzece> lista = baza.Poduzeca.ToList();

            return View(lista);
        }

 

    }
}