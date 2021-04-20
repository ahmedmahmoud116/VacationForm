using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Service.Services
{
    public interface IEmployeeRequestService
    {
        void AddEmployeeRequest(EmployeeRequest employeeRequest); //to add EmployeeRequest
        List<VacationRequestView> GetAllEmployeeRequests();
        EmployeeRequest GetEmployeeRequest(int id);
        EmployeeRequest DeleteEmployeeRequest(int id);
        void UpdateEmployeeRequest(EmployeeRequest employeeRequest); //to edit EmployeeRequest
        public void StateEmployeeRequest(EmployeeRequest employeeRequest, EntityState state); //to return state of employee
        public void SaveEmployeeRequest(); //to save changes in the db
        public bool EmployeeRequestExists(int id); //in service only
        public bool employeeRequestValidationPost(EmployeeRequest employeeRequest); //to validate post request
        public bool employeeRequestValidationEdit(EmployeeRequest employeeRequest, int currval); //to validate edit request
    }
}
