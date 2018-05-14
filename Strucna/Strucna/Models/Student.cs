using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    public class Student
    {
        public int id_student { get; set; }
        public string ime_prezime { get; set; }
        public string adresa { get; set; }
        public string mob { get; set; }
        public string email { get; set; }
        public string lozinka { get; set; }
        public string aktivacijski_link { get; set; }
        public int aktivan { get; set; }
        public int id_studij { get; set; }
        public int izvanredni { get; set; }
    }
}