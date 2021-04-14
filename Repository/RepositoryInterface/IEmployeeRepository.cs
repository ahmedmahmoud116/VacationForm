using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;
using Microsoft.EntityFrameworkCore;
using Data.Factory;

namespace Repository.RepositoryInterface
{
    public interface IEmployeeRepository
    {

        void AddEmployee(Employee employee); //to add employee
        List<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        Employee GetEmployee(string name);
        Employee DeleteEmployee(int id);
        void UpdateEmployee(Employee employee); //to edit employee
        public void StateEmployee(Employee employee, EntityState state); //to return state of employee
        public void SaveEmployee(); //to save changes in the db
    }
}
