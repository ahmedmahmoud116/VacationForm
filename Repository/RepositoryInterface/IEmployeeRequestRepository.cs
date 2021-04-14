using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.RepositoryInterface
{
    public interface IEmployeeRequestRepository
    {
        void AddEmployeeRequest(EmployeeRequest employeeRequest); //to add EmployeeRequest
        List<VacationRequestView> GetAllEmployeeRequests();
        EmployeeRequest GetEmployeeRequest(int id);
        EmployeeRequest DeleteEmployeeRequest(int id);
        void UpdateEmployeeRequest(EmployeeRequest employeeRequest); //to edit EmployeeRequest
        public void StateEmployeeRequest(EmployeeRequest vacation, EntityState state); //to return state of EmployeeRequest
        public void SaveEmployeeRequest(); //to save changes in the db
    }
}
