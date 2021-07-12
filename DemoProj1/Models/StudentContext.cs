using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProj1.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions <StudentContext> options) : base(options)
        {
            
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<studentDetails1> studentDetails1 { get; set; }
    }
}
