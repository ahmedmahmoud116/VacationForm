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
        public void CreateEmployee(Employee employee)
        {
            employeeEntity.Add(employee);
            context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = GetEmployee(id);
            employeeEntity.Remove(employee);
            context.SaveChanges();
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
    }
}
