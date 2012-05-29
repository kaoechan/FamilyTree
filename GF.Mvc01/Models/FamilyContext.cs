using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GF.Mvc01.Models
{
    public class FamilyContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Family> Families { get; set; }
    }
}