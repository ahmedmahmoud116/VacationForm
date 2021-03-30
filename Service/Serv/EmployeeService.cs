using System.Collections.Generic;
using Service.Services;
using Repository.RepositoryInterface;
using Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Service.Serv
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeService(IEmployeeRepository employeeRepo)
        {
            this._employeeRepo = employeeRepo;
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepo.AddEmployee(employee);
        }

        public Employee DeleteEmployee(int id)
        {
            return _employeeRepo.DeleteEmployee(id);
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepo.GetAllEmployees();
        }

        public Employee GetEmployee(int id)
        {
            return _employeeRepo.GetEmployee(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepo.UpdateEmployee(employee);
        }

        public void StateEmployee(Employee employee, EntityState state)
        {
            _employeeRepo.StateEmployee(employee, state);
        }

        public void SaveEmployee()
        {
            _employeeRepo.SaveEmployee();
        }

        public bool EmployeeExists(int id)
        {
            return _employeeRepo.GetEmployee(id) == null ? false : true;
        }
    }
}
