using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    public class Praksa
    {
        public int id_praksa { get; set; }
        public int id_studij { get; set; }
        public int id_mentor { get; set; }
        public string naziv { get; set; }
        public DateTime datum_od { get; set; }
        public DateTime datum_do { get; set; }
        public int zavrsena { get; set; }

    }
}