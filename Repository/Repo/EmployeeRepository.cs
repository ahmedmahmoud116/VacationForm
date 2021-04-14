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
        private readonly IDbFactory dbFactory;
        private readonly VacationContext _context;

        public EmployeeRepository(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            this._context = dbFactory.init();
        }

        public VacationContext context
        {
            get { return _context == null ? dbFactory.init() : _context; }
        }

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

        public Employee GetEmployee(string FullName)
        {
            return context.Employees.SingleOrDefault(e => e.FullName.Equals(FullName));
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

    }
}
