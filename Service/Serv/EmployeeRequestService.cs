using System.Collections.Generic;
using Service.Services;
using Repository.RepositoryInterface;
using Model.Models;

namespace Service.Serv
{
    class EmployeeRequestService : IEmployeeRequestService
    {
        private readonly IEmployeeRequestRepository _employeeRequestRepo;

        public EmployeeRequestService(IEmployeeRequestRepository employeeRequestRepository)
        {
            this._employeeRequestRepo = employeeRequestRepository;
        }

        public void CreateEmployeeRequest(EmployeeRequest employeeRequest)
        {
            _employeeRequestRepo.CreateEmployeeRequest(employeeRequest);
        }

        public void DeleteEmployeeRequest(int id)
        {
            _employeeRequestRepo.DeleteEmployeeRequest(id);
        }

        public List<EmployeeRequest> GetAllEmployeeRequests()
        {
            return _employeeRequestRepo.GetAllEmployeeRequests();
        }

        public EmployeeRequest GetEmployeeRequest(int id)
        {
            return _employeeRequestRepo.GetEmployeeRequest(id);
        }

        public void UpdateEmployeeRequest(EmployeeRequest employeeRequest)
        {
            _employeeRequestRepo.UpdateEmployeeRequest(employeeRequest);
        }
    }
}
