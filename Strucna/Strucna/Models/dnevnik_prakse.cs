using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    public class Dnevnik_prakse
    {
        public int id_praksa { get; set; }
        public int id_student { get; set; }
        public int red_broj { get; set; }
        public DateTime datum { get; set; }
        public string naslov { get; set; }
        public string opis { get; set; }
    }
}