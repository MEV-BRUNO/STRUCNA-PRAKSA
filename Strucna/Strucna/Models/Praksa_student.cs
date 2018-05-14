using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    public class Praksa_student
    {
        public int id_praksa { get; set; }
        public int id_student { get; set; }
        public int id_poduzece { get; set; }
        public DateTime datum_od { get; set; }
        public DateTime datum_do { get; set; }
        public int odobreno { get; set; }
        public int ocjena { get; set; }
    }
}