using System.Collections.Generic;
using Service.Services;
using Repository.RepositoryInterface;
using Model.Models;

namespace Service.Serv
{
    class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeService(IEmployeeRepository employeeRepo)
        {
            this._employeeRepo = employeeRepo;
        }

        public void CreateEmployee(Employee employee)
        {
            _employeeRepo.CreateEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepo.DeleteEmployee(id);
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
    }
}
