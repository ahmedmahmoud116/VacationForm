using VacationForm.Models;
using Microsoft.EntityFrameworkCore;

namespace VacationForm.DBContexts
{
    public class VacationContext : DbContext
    {
        public VacationContext(DbContextOptions<VacationContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }  //plural for convetions
        public DbSet<EmployeeBalance> EmployeeBalances { get; set; }
        public DbSet<EmployeeRequest> EmployeeRequests { get; set; }
        public DbSet<Vacation> Vacations { get; set; }

        

    }
}
