using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    [Table("dnevnik_prakse")]
    public class Dnevnik_prakse
    {
        [Required]
        [Key]
        public int id_dnevnik { get; set; }
        public int id_praksa { get; set; }
        public int id_student { get; set; }
        
        [Display(Name = "Redni broj")]
        public int red_broj { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Datum")]
        public DateTime datum { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Naslov")]
        public string naslov { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Opis")]
        public string opis { get; set; }
    }
}