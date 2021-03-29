using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;

namespace Repository.RepositoryInterface
{
    public interface IEmployeeRequestRepository
    {
        void CreateEmployeeRequest(EmployeeRequest employeeRequest); //to add EmployeeRequest
        List<EmployeeRequest> GetAllEmployeeRequests();
        EmployeeRequest GetEmployeeRequest(int id);
        void DeleteEmployeeRequest(int id);
        void UpdateEmployeeRequest(EmployeeRequest employeeRequest); //to edit EmployeeRequest
    }
}
