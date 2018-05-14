using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    public class Prijava
    {
        public int id_praksa { get; set; }
        public int id_student { get; set; }
        public DateTime datum { get; set; }
        public int id_poduzece { get; set; }
        public int odobreno { get; set; }

    }
}