using System;
using System.Collections.Generic;
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
    }
    }
