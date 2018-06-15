using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strucna.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult index_student()
        {
            return View();
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



        public ActionResult prijava_studenta()
        {
            return View();
        }
    }
}