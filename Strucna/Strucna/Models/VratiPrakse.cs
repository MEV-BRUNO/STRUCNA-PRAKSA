using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    public class VratiPrakse
    {
        public int id_praksa { get; set; }
        public string studij { get; set; }

        public string mentor { get; set; }

        public string datoum_od { get; set; }

        public string datoum_do { get; set; }

        public string naziv { get; set; }

        public string zavrsena { get; set; }
    }
}