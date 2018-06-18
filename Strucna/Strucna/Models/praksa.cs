using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    [Table("praksa")]
    public class Praksa
    {
        [Required]
        [Key]
        public int id_praksa { get; set; }
        [Display(Name = "Ime Mentora")]
        public int id_studij { get; set; }
        [Display(Name = "Ime Mentora")]
        public int id_mentor { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Naziv")]
        public string naziv { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Od")]
        public DateTime datum_od { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Do")]
        public DateTime datum_do { get; set; }
        [Display(Name = "Završeno")]
        public int zavrsena { get; set; }

    }
}