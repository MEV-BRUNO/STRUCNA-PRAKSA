﻿using System;
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
        public int id_studnet { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Ime i Prezime")]
        public string ime_prezime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Adresa")]
        public string adresa { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Broj mobitela")]
        public string mob { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email adresa")]
        public string email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Lozinka")]
        public string lozinka { get; set; }


        [NotMapped]
         
        [Display(Name = "Ponovite Lozinku")]
        public string ConfirmLozinka { get; set; }


        public string aktivacijski_link { get; set; }

        
        public byte aktivan { get; set; }

     
        [Display(Name = "Studij")]
        public int id_studij { get; set; }
    

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Redovni/Izvanredi")]
        public short izvanredni{ get; set; }

         
        public string password_reset { get; set; }
    }
 
}


