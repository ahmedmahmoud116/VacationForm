using VacationForm.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace VacationForm.DBContexts
{
    public class VacationContext : DbContext
    {
        public VacationContext(DbContextOptions<VacationContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeBalance> EmployeeBalance { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Vacation> Vacations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map entities to tables  
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<EmployeeBalance>().ToTable("EmployeeBalance");
            modelBuilder.Entity<Request>().ToTable("Request");
            modelBuilder.Entity<Vacation>().ToTable("Vacation");


        }
        

    }
}
