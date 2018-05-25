using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    [Table("prijava")]
    public class Prijava
    {
        [Required]
        [Key]
        public int id_praksa { get; set; }
        public int id_student { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Datum")]
        public DateTime datum { get; set; }
        public int id_poduzece { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Odobreno")]
        public int odobreno { get; set; }

    }
}