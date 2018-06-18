using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Strucna.Baza_povezivanje;
using Strucna.Models;

namespace Strucna.ViewModels
{
    public class PraksaViewModel
    {
       
        strucnapraksa baza = new strucnapraksa();
        public Studij Studij { get; set; }

        public Mentor Mentori { get; set; }

        public Praksa Praksa { get; set; }

        public IEnumerable<SelectListItem> FlavorItems
        {
            get
            {
                var allFlavors = baza.Mentori.Select(f => new SelectListItem
                {
                    Value = f.id_mentor.ToString(),
                    Text = f.ime_prezime
                });
                return DefaultFlavorItem.Concat(allFlavors);
            }
        }

        public IEnumerable<SelectListItem> DefaultFlavorItem
        {
            get
            {
                return Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "Select a flavor"
                }, count: 1);
            }
        }



    }
}