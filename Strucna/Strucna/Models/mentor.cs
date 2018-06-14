using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    [Table("mentor")]
    public class Mentor {
 

        [Required]
        [Key]
        public int id_mentor { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Ime i Prezime")]
        public string ime_prezime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Email adresa")]
        public string email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Lozinka")]
        public string lozinka { get; set; }
        [NotMapped]
        [Compare("lozinka", ErrorMessage = "Šifre se ne podudaraju!")]
        [Display(Name = "Ponovite Lozinku")]
        public string ConfirmLozinka { get; set; }

        [Display(Name = "ID studij")]
        public int id_studij { get; set; }

    }
}
