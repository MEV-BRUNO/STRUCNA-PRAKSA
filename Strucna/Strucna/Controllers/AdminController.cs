﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strucna.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult index_admin()
        {
            return View();
        }

        public ActionResult popis_studijskih_programa()
        {
            return View();
        }
        public ActionResult strucna_praksa()
        {
            return View();
        }

    

        public ActionResult o_praksi()
        {
            return View();
        }

  

        public ActionResult dokumenti()
        {
            return View();
        }

        public ActionResult poduzeca()
        {
            return View();
        }

        public ActionResult prijava_studenta()
        {
            return View();
        }

    }
}