using System;
using System.Collections.Generic;
using System.Text;
using Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Service.Services
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee); //to add employee
        List<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        Employee GetEmployee(string name);
        Employee DeleteEmployee(int id);
        void UpdateEmployee(Employee employee); //to edit employee
        public void StateEmployee(Employee employee, EntityState state); //to return state of employee
        public void SaveEmployee(); //to save changes in the db
        public bool EmployeeExists(int id); //in service only
        public bool EmployeeExists(string FullName);
    }
}
