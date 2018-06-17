using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    public class VratiStudente
    {

        public int id_student { get; set; }
        public string ime { get; set; }

        public string poduzece { get; set; }

        public string datoum_od { get; set; }

        public string datoum_do { get; set; }

        public string odobreno { get; set; }

        public string ocjena { get; set; }
    }
}