using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Strucna.Models
{
    [Table("praksa_student")]
    public class Praksa_student
    {
        [Required]
        [Key]

        public int id_praksastudent { get; set; }
        [Display(Name = "Naziv prakse")]
        public int id_praksa { get; set; }
        public int id_student { get; set; }
        [Display(Name = "Naziv poduzeća")]
        public int id_poduzece { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Od")]
        public DateTime datum_od { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Do")]
        public DateTime datum_do { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Odobreno")]
        public int odobreno { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Ocjena")]
        public int ocjena { get; set; }
    }
}