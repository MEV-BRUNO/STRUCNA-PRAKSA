using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    public class Ocjena
    {
        public int id_praksa { get; set; }
        public int id_student { get; set; }
        public DateTime datum { get; set; }
        public int izvjesce_predano { get; set; }
        public string izvjesce_dokument { get; set; }
        public int potvrda_predano { get; set; }
        public string potvrda_dokument { get; set; }
        public int anketa_predano { get; set; }
        public string anketa_dokument { get; set; }
        public int zahtjev_predano { get; set; }
        public string zahtjev_dokument { get; set; }
        public string ocjena { get; set; }
    }
}