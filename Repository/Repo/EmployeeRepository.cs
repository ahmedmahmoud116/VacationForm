using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryInterface;
using Data.DBContexts;
using Data.Factory;

namespace Repository.Repo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //private readonly IUnitOfWork unitOfWork;
        private IDbFactory dbFactory;
        private VacationContext _context;
        //private DbSet<Employee> _employeeEntity;

        public EmployeeRepository(IDbFactory dbFactory, VacationContext context)
        {
            this.dbFactory = dbFactory;
            this._context = dbFactory.init();
            //this._employeeEntity = _context.Set<Employee>();
        }

        public VacationContext context
        {
            get { return _context == null ? dbFactory.init() : _context; }
        }

        //public DbSet<Employee> employeeEntity
        //{
        //    set { _employeeEntity =  context.Set<Employee>(); }
        //}
        public void AddEmployee(Employee employee)
        {
            context.Add(employee);
            //context.SaveChanges();
        }

        public Employee DeleteEmployee(int id)
        {
            Employee employee = GetEmployee(id);
            context.Remove(employee);
            //context.SaveChanges();
            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            return context.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return context.Employees.SingleOrDefault(e => e.ID == id);
        }

        public void UpdateEmployee(Employee employee)
        {
            context.Update(employee);
            //context.SaveChanges();
        }

        public void StateEmployee(Employee employee, EntityState state)
        {
            context.Entry(employee).State = state;
        }
        public void SaveEmployee()
        {
            context.SaveChangesAsync();
        }
        public Employee GetEmployee(string FullName)
        {
            return context.Employees.SingleOrDefault(e => e.FullName.Equals(FullName));
        }
    }
}
