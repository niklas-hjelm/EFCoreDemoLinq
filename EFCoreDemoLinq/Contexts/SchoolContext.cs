﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using EFCoreDemoLinq.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemoLinq.Contexts
{
    class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=SchoolDemoDB;Trusted_Connection=True;");
        }
    }
}
