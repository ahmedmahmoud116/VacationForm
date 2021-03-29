using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;

namespace Repository.RepositoryInterface
{
    public interface IEmployeeRepository
    {
        void CreateEmployee(Employee employee); //to add employee
        List<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        void DeleteEmployee(int id);
        void UpdateEmployee(Employee employee); //to edit employee
    }
}
