using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DBContexts;
using Model.Models;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryInterface;

namespace Repository.Repo
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private VacationContext context;
        private DbSet<Employee> employeeEntity;

        public EmployeeRepository(VacationContext context)
        {
            this.context = context;
            employeeEntity = context.Employees;
        }
        public void AddEmployee(Employee employee)
        {
            employeeEntity.Add(employee);
            context.SaveChanges();
        }

        public Employee DeleteEmployee(int id)
        {
            Employee employee = GetEmployee(id);
            employeeEntity.Remove(employee);
            context.SaveChanges();
            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeEntity.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return employeeEntity.SingleOrDefault(e => e.ID == id);
        }

        public void UpdateEmployee(Employee employee)
        {
                employeeEntity.Update(employee);
                context.SaveChanges();
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
