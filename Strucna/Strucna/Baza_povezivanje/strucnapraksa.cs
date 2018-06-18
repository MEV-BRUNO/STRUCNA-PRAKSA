using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Strucna.Models;

namespace Strucna.Baza_povezivanje
{
    public class strucnapraksa : DbContext
    {
        


        public DbSet<Mentor> Mentori { get; set; }

        public DbSet<Student> Studenti { get; set; } 

        public DbSet<Poduzece> Poduzeca { get; set; }

        public DbSet<Praksa_student> PraksaStudent { get; set; }

        public DbSet<Studij> Smjerovi { get; set; }

        public DbSet<Dokumenti> Dokument { get; set; }

        public DbSet<Dnevnik_prakse> Dnevnik { get; set; }

        public DbSet<Praksa> Prakse { get; set; }
    }
}
