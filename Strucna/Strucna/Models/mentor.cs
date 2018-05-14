using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strucna.Models
{

    public class Mentor { 

        public int id_mentor { get; set; }

        public string ime_prezime { get; set; }

        public string email { get; set; }
        public string lozinka { get; set; }
        public int id_studij { get; set; }

    }
}