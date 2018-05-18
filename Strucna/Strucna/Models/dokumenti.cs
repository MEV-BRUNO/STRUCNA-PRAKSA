using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    [Table("dokumenti")]

    public class Dokumenti
    {
        [Required]
        [Key]
        public int id_dokument { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Naziv")]
        public string naziv { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Put")]
        public string put { get; set; }

    }
}