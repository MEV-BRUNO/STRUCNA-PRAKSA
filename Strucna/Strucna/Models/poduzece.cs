using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    public class Poduzece
    {
        public int id_poduzece { get; set; }
        public string naziv { get; set; }
        public string adresa { get; set; }
        public string grad { get; set; }
        public string opis { get; set; }
        public string kontakt_osoba { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public string URL { get; set; }

    }
}