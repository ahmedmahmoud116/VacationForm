using System.Collections.Generic;
using Service.Services;
using Repository.RepositoryInterface;
using Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Service.Serv
{
    public class EmployeeRequestService : IEmployeeRequestService
    {
        private readonly IEmployeeRequestRepository _employeeRequestRepo;

        public EmployeeRequestService(IEmployeeRequestRepository employeeRequestRepository)
        {
            this._employeeRequestRepo = employeeRequestRepository;
        }

        public void AddEmployeeRequest(EmployeeRequest employeeRequest)
        {
            _employeeRequestRepo.AddEmployeeRequest(employeeRequest);
        }

        public EmployeeRequest DeleteEmployeeRequest(int id)
        {
            return _employeeRequestRepo.DeleteEmployeeRequest(id);
        }

        public List<VacationRequestView> GetAllEmployeeRequests()
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
        public void StateEmployeeRequest(EmployeeRequest employeeRequest, EntityState state)
        {
            _employeeRequestRepo.StateEmployeeRequest(employeeRequest, state);
        }
        public void SaveEmployeeRequest()
        {
            _employeeRequestRepo.SaveEmployeeRequest();
        }

        public bool EmployeeRequestExists(int id)
        {
            return _employeeRequestRepo.GetEmployeeRequest(id) == null ? false : true;
        }
    }
}
