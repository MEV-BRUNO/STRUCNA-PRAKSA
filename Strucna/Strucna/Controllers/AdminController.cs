using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Strucna.Baza_povezivanje;
using Strucna.Models;
using Rotativa.MVC;


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
            List<VratiPrakse> vrati = new List<VratiPrakse>();
            List<Mentor> mentori = baza.Mentori.ToList();
            List<Studij> studiji = baza.Smjerovi.ToList();

            foreach (Praksa praksa in baza.Prakse.ToList())
            {
                VratiPrakse privemeno = new VratiPrakse();
                privemeno.id_praksa = praksa.id_praksa;
                privemeno.naziv = praksa.naziv;
                privemeno.datoum_do = praksa.datum_do.ToString();
                privemeno.datoum_od = praksa.datum_od.ToString();
                if (praksa.zavrsena == 0)
                {
                    privemeno.zavrsena = "NE";

                }
                else
                {
                    privemeno.zavrsena = "DA";
                }

                foreach (Mentor mentor in mentori)
                {
                    if (mentor.id_mentor == praksa.id_mentor )
                    {
                        privemeno.mentor = mentor.ime_prezime;
                    }
                }
                foreach (Studij studij in studiji)
                {
                    if (studij.id_studij == praksa.id_studij)
                    {
                        privemeno.studij = studij.naziv;
                    }
                }

                vrati.Add(privemeno);

            }
           

            return View(vrati);
        }

        public ActionResult dnevnik(int id)
        {
            List<Dnevnik_prakse> lista = new List<Dnevnik_prakse>();
            foreach (Dnevnik_prakse dok in baza.Dnevnik)
            {
                if (dok.id_student == id)
                {
                    lista.Add(dok);
                }
                

            }
            return View(lista);
        }

        public ActionResult dnevnikDetalji(int id)
        {
            Dnevnik_prakse a = baza.Dnevnik.SingleOrDefault(s => s.id_dnevnik == id);
            List<Dnevnik_prakse> lista = new List<Dnevnik_prakse>();
            lista.Add(a);

            return View(lista);
        }

        public ActionResult editPraksa(int id)
        {
            Session["editPID"] = id;
  
            Praksa praksaToUpdate = baza.Prakse.SingleOrDefault(s => s.id_praksa == id);
            praksaToUpdate.datum_od = praksaToUpdate.datum_od.Date;
            praksaToUpdate.datum_do = praksaToUpdate.datum_do.Date;
            return View(praksaToUpdate);
 

        }

        [HttpPost]
        public ActionResult editPraksa(Praksa p)
        {
           
            int studijID = (int)Session["editPID"];

            Praksa praksaToUpdate = baza.Prakse.SingleOrDefault(s => s.id_praksa == studijID);
            praksaToUpdate.id_mentor = p.id_mentor;
            praksaToUpdate.id_studij = p.id_studij;
            praksaToUpdate.datum_od = p.datum_od;
            praksaToUpdate.datum_do = p.datum_do;
            praksaToUpdate.naziv = p.naziv;
            praksaToUpdate.zavrsena = p.zavrsena;

            baza.SaveChanges();
            Session["editPID"] = null;
            return RedirectToAction("strucna_praksa");


        }

        public ActionResult addPraksa()
        {

           
            
 
            return View( );

        }
        [HttpPost]
        public ActionResult addPraksa(Praksa p)
        {

            baza.Prakse.Add(p);
            baza.SaveChanges();


            return RedirectToAction("strucna_praksa");

        }

        [HttpGet]
        public ActionResult deletePraksa(int id)
        {
            Praksa praksaToDelete = baza.Prakse.SingleOrDefault(s => s.id_praksa == id);

            baza.Prakse.Remove(praksaToDelete);
            baza.SaveChanges();


            return RedirectToAction("strucna_praksa");
        }

        public FileResult Download(int id)
        {
            Dokumenti dok = baza.Dokument.SingleOrDefault(s => s.id_dokument == id);
             
            byte[] fileBytes = System.IO.File.ReadAllBytes(dok.put);
            string fileName = dok.naziv;
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
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
                else if (praksa.ocjena == 2)
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

        public ActionResult approveStudent(int id)
        {

            Praksa_student studentToUpdate = baza.PraksaStudent.SingleOrDefault(s => s.id_student == id);
            if (studentToUpdate.odobreno == 0)
            {
                studentToUpdate.odobreno = 1;

            }
            else
            {
                studentToUpdate.odobreno = 0;
            }

            baza.SaveChanges();

            return RedirectToAction("o_praksi");

        }

        public ActionResult deleteStudent(int id)
        {


            Praksa_student praksaToDelte = baza.PraksaStudent.SingleOrDefault(s => s.id_student == id);

            if(praksaToDelte != null) { 

            baza.PraksaStudent.Remove(praksaToDelte);
            baza.SaveChanges();
            }

            Student sutdentToDelete = baza.Studenti.SingleOrDefault(s => s.id_studnet == id);

            baza.Studenti.Remove(sutdentToDelete);
            baza.SaveChanges();



            return RedirectToAction("o_praksi");
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

        public ActionResult gradeStudent(int id)
        {
            Session["gradeID"] = id;
            Praksa_student ps = baza.PraksaStudent.SingleOrDefault(s => s.id_student == id);
            return View(ps);
        }
        [HttpPost]
        public ActionResult gradeStudent(Praksa_student praksaStudent)
        {
            int id =(int)Session["gradeID"];
            Praksa_student ps = baza.PraksaStudent.SingleOrDefault(s => s.id_student == id);
            ps.ocjena = praksaStudent.ocjena;
         
            baza.SaveChanges();
            return RedirectToAction("o_praksi");
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

            if (d.naziv == null)
            {

                return View();

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

        public ActionResult editPoduzeca( int id)
        {
            Poduzece poduzeceToUpdate = baza.Poduzeca.SingleOrDefault(s => s.id_poduzece == id);
            Session["editPod"] = id;
            return View(poduzeceToUpdate);
        }

        [HttpPost]
        public ActionResult editPoduzeca(Poduzece p)
        {

            if (ModelState.IsValid) { 

            int broj = (int) Session["editPod"];
            Poduzece poduzeceToUpdate = baza.Poduzeca.SingleOrDefault(s => s.id_poduzece == broj);
            poduzeceToUpdate.naziv = p.naziv;
            poduzeceToUpdate.adresa = p.adresa;
            poduzeceToUpdate.URL = p.URL;
            poduzeceToUpdate.email = p.email;
            poduzeceToUpdate.grad = p.grad;
            poduzeceToUpdate.kontakt_osoba = p.kontakt_osoba;
            poduzeceToUpdate.opis = p.opis;
            poduzeceToUpdate.tel = p.tel;

            baza.SaveChanges();
            Session["editPod"] = null;
            return RedirectToAction("poduzeca");
            }
            else
            {
                return View(p);
            }
        }

        public ActionResult dodajSmjer()
        {

            return View();

        }
        public ActionResult detailsPoduzeca(int id)
        {
            Poduzece poduzeceToUpdate = baza.Poduzeca.SingleOrDefault(s => s.id_poduzece == id);
            List<Poduzece> lista = new List<Poduzece>();
            lista.Add(poduzeceToUpdate);
            return View(lista);
        }

        public ActionResult deletePoduzeca(int id)
        {
            Poduzece poduzeceToDelete = baza.Poduzeca.SingleOrDefault(s => s.id_poduzece == id);

            baza.Poduzeca.Remove(poduzeceToDelete);
            baza.SaveChanges();


            return RedirectToAction("poduzeca");
        }

        public ActionResult editStudent(int id)
        {
            Session["editStud"] = id;
            Student studentToUpdate = baza.Studenti.SingleOrDefault(s => s.id_studnet == id);


            return View(studentToUpdate);
        }
        [HttpPost]
        public ActionResult editStudent(Student stud)
        {
            int id =(int)Session["editStud"];
            Student studentToUpdate = baza.Studenti.SingleOrDefault(s => s.id_studnet == id);
            studentToUpdate.id_studij = stud.id_studij;
            studentToUpdate.izvanredni = stud.izvanredni;

            return View();
        }
        [HttpPost]
        public ActionResult dodajSmjer(Studij studij)
        {

            baza.Smjerovi.Add(studij);
            baza.SaveChanges();

            return RedirectToAction("popis_studijskih_programa");

        }

        [HttpGet]
        public ActionResult deleteSmejer(int id)
        {
            Studij studijToDelete = baza.Smjerovi.SingleOrDefault(s => s.id_studij == id);

            baza.Smjerovi.Remove(studijToDelete);
            baza.SaveChanges();


          return RedirectToAction("popis_studijskih_programa");
        }


        public ActionResult editSmjer(string id)
        {
            Session["ID"] = id;
            int studijID = Int32.Parse(id);
            Studij studijToUpdate = baza.Smjerovi.SingleOrDefault(s => s.id_studij == studijID);
            return View(studijToUpdate);
        }

        [HttpPost]
        public ActionResult editSmjer(Studij s)
        {


            string provjera = (string)Session["ID"];
            int broj = Int32.Parse(provjera);
           
            Studij studijToUpdate = baza.Smjerovi.SingleOrDefault(studij => studij.id_studij == broj);
            studijToUpdate.naziv = s.naziv;

            baza.SaveChanges();
            Session["ID"] = null;
            return RedirectToAction("popis_studijskih_programa");
        }

        [HttpGet]
        public ActionResult addPoduzece()
        {
            Poduzece p = new Poduzece();

            return View(p);
        }

        [HttpPost]
        public ActionResult addPoduzece(Poduzece p)
        {

            List<Praksa> listaPrkse = baza.Prakse.ToList();

            if (ModelState.IsValid)
            {

                baza.Poduzeca.Add(p);
                baza.SaveChanges();

                return RedirectToAction("index_admin");
            }
            else
            {
                return View(p);
            }


        }

        public ActionResult podaci()
        {

            List<VratiStudente> lista = new List<VratiStudente>();
            List<Student> listaStudenata = baza.Studenti.ToList();
            List<Poduzece> listaSPoduzeca = baza.Poduzeca.ToList();
            foreach (Student student in listaStudenata)
            {
                VratiStudente a = new VratiStudente();

                a.id_student = student.id_studnet;
                a.ime = student.ime_prezime;
                a.datoum_od = "00/00/0000";
                a.datoum_do = "00/00/0000";
                a.odobreno = "Nije prijavljeno";
                a.ocjena = "Nije prijavljeno";
                a.poduzece = "Nije prijavljeno";

                foreach (Praksa_student praksa in baza.PraksaStudent)
                {
                    if (student.id_studnet == praksa.id_student)
                    {

                        foreach (Poduzece poduzece in listaSPoduzeca)
                        {
                            if (poduzece.id_poduzece == praksa.id_poduzece)
                            {

                                a.poduzece = poduzece.naziv;


                            }
                        }

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
                        else if (praksa.ocjena == 2)
                        {
                            a.ocjena = "Negativno";
                        }

                       
                    }
                     
                     
                     
                   
                }

                lista.Add(a);


            }


            return View(lista);
        }

        
        public ActionResult PrintStudnets()
        {
            ActionAsPdf resoult = new ActionAsPdf("podaci")
            {
                FileName = Server.MapPath("~/Content/Invoice.pdf")
            };

            return resoult;
        }

    }
}