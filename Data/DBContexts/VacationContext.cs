using Model.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.DBContexts
{
    public class VacationContext : DbContext
    {
        public VacationContext(DbContextOptions<VacationContext> options) : base(options)
        {
        }

        public VacationContext(Func<object, object> p)
        {
        }

        public DbSet<Employee> Employees { get; set; }  //plural for conventions
        public DbSet<EmployeeBalance> EmployeeBalances { get; set; }
        public DbSet<EmployeeRequest> EmployeeRequests { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<VacationView> VacationViews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /**Validation**/
            //modelBuilder.Entity<Employee>(entity =>
            //{
            //    entity.HasIndex(e => e.Email).IsUnique();
            //});
            //modelBuilder.Entity<Vacation>(entity =>
            //{
            //    entity.HasIndex(e => e.Type).IsUnique();
            //});

            //PostSeed for employee
            modelBuilder.Entity<Employee>().HasData(new Employee { ID = 4572, FullName = "Ahmed Mahmouud", Email = "ahmed@gmail.com"
                , Gender = "Male", BirthDate = Convert.ToDateTime("1998-05-31")});
            modelBuilder.Entity<Employee>().HasData(new Employee { ID = 4777, FullName = "Marwan Salem", Email = "marwan@gmail.com"
                , Gender = "Male", BirthDate = Convert.ToDateTime("1998-11-08")});
            modelBuilder.Entity<Employee>().HasData(new Employee { ID = 4999, FullName = "Nadine Ahmed", Email = "nadine@gmail.com"
                , Gender = "Female", BirthDate = Convert.ToDateTime("1999-02-20")});

            modelBuilder.Entity<EmployeeBalance>(entity => {entity.HasOne(e => e.Employee).WithMany(eb => eb.EmployeeBalance)
                .HasForeignKey("EmployeeID");});
            modelBuilder.Entity<EmployeeRequest>(entity => {entity.HasOne(e => e.Employee).WithMany(er => er.EmployeeRequest)
                .HasForeignKey("EmployeeID");});

            //PostSeed for vacation
            modelBuilder.Entity<Vacation>().HasData(new Vacation {ID = 1, Type = "casual", Balance = 7});
            modelBuilder.Entity<Vacation>().HasData(new Vacation { ID = 2, Type = "schedule", Balance = 14});

            modelBuilder.Entity<EmployeeBalance>(entity => {entity.HasOne(e => e.Vacation).WithMany(eb => eb.EmployeeBalance)
                .HasForeignKey("VacationID");});
            modelBuilder.Entity<EmployeeRequest>(entity => {entity.HasOne(e => e.Vacation).WithMany(er => er.EmployeeRequest)
                .HasForeignKey("VacationID");});

            //PostSeed for EmployeeBalance
            modelBuilder.Entity<EmployeeBalance>().HasData(new EmployeeBalance { ID = 1, EmployeeID = 4572
                , VacationID = 1 , Balance = 7});
            modelBuilder.Entity<EmployeeBalance>().HasData(new EmployeeBalance { ID = 2, EmployeeID = 4572
                , VacationID = 2 , Balance = 14});
            modelBuilder.Entity<EmployeeBalance>().HasData(new EmployeeBalance { ID = 3, EmployeeID = 4777
                , VacationID = 1 , Balance = 5});
            modelBuilder.Entity<EmployeeBalance>().HasData(new EmployeeBalance { ID = 4, EmployeeID = 4777
                , VacationID = 2 , Balance = 12});
            modelBuilder.Entity<EmployeeBalance>().HasData(new EmployeeBalance { ID = 5, EmployeeID = 4999
                , VacationID = 1 , Balance = 7});
            modelBuilder.Entity<EmployeeBalance>().HasData(new EmployeeBalance { ID = 6, EmployeeID = 4999
                , VacationID = 2 , Balance = 14});

            //PostSeed for EmployeeRequest
            modelBuilder.Entity<EmployeeRequest>().HasData(new EmployeeRequest { ID = 1, EmployeeID = 4572
                , VacationID = 1 , Days = 3});
            modelBuilder.Entity<EmployeeRequest>().HasData(new EmployeeRequest { ID = 2, EmployeeID = 4777
                , VacationID = 2 , Days = 5});
            modelBuilder.Entity<EmployeeRequest>().HasData(new EmployeeRequest { ID = 3, EmployeeID = 4999
                , VacationID = 2 , Days = 6});
            modelBuilder.Entity<EmployeeRequest>().HasData(new EmployeeRequest { ID = 4, EmployeeID = 4572
                , VacationID = 1 , Days = 2});

            modelBuilder.Entity<VacationView>().HasKey(v => v.ID);
        }


    }
}
