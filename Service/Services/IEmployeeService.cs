using System;
using System.Collections.Generic;
using System.Text;
using Model.Models;

namespace Service.Services
{
    interface IEmployeeService
    {
        void CreateEmployee(Employee employee); //to add employee
        List<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        void DeleteEmployee(int id);
        void UpdateEmployee(Employee employee); //to edit employee
    }
}
