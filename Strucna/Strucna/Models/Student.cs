using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    [Table("student")]
    public class Student
    {
        [Required]
        [Key]
        public int id_student { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Ime i Prezime")]
        public string ime_prezime { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Adresa")]
        public string adresa { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Broj mobitela")]
        public string mob { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Email adresa")]
        public string email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Lozinka")]
        public string lozinka { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Aktiv link")]
        public string aktivacijski_link { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Aktivan")]
        public int aktivan { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "ID studij")]
        public int id_studij { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Izvanredni")]
        public int izvanredni { get; set; }
    }
}
