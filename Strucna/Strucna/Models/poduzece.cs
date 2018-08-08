using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    [Table("poduzece")]
    public class Poduzece
    {
        [Required]
        [Key]
        public int id_poduzece { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Naziv firme")]
        public string naziv { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Adresa poduzeća")]
        public string adresa { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Mjest/grad")]
        public string grad { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Opis poslova")]
        public string opis { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Kontakt osoba")]
        public string kontakt_osoba { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Telefon")]
        public string tel { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email poduzeća")]
        public string email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "URL")]
        public string URL { get; set; }

    }
}