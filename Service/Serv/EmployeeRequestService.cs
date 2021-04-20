using System.Collections.Generic;
using Service.Services;
using Repository.RepositoryInterface;
using Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Service.Serv
{
    public class EmployeeRequestService : IEmployeeRequestService
    {
        private readonly IEmployeeRequestRepository _employeeRequestRepo;
        private readonly IEmployeeBalanceRepository _employeeBalanceRepo;

        public EmployeeRequestService(IEmployeeRequestRepository employeeRequestRepository, IEmployeeBalanceRepository employeeBalanceRepository)
        {
            this._employeeRequestRepo = employeeRequestRepository;
            this._employeeBalanceRepo = employeeBalanceRepository;
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

        public bool employeeRequestValidationPost(EmployeeRequest employeeRequest)
        {
            return positiveValidator(employeeRequest.Days) || checkVacaionDaysPost(employeeRequest);
        }

        public bool employeeRequestValidationEdit(EmployeeRequest employeeRequest, int currval)
        {
            return positiveValidator(employeeRequest.Days) || checkVacaionDaysEdit(employeeRequest, currval);
        }

        private bool positiveValidator(int number)
        {
            Regex regex = new Regex(@"^[1-9]+[0-9]*$");
            Match match = regex.Match(number.ToString());
            return !match.Success;
        }

        private bool checkVacaionDaysPost(EmployeeRequest employeeRequest)
        {
            List<VacationView> vacationViews = _employeeBalanceRepo.GetAllEmployeeBalances();
            var vacationview = vacationViews.Find(v => v.employeeID == employeeRequest.EmployeeID && v.vacationID == employeeRequest.VacationID);
            return employeeRequest.Days > (vacationview.Balance - vacationview.Used);
        }
        private bool checkVacaionDaysEdit(EmployeeRequest employeeRequest, int currval)
        {
            List<VacationView> vacationViews = _employeeBalanceRepo.GetAllEmployeeBalances();
            var vacationview = vacationViews.Find(v => v.employeeID == employeeRequest.EmployeeID && v.vacationID == employeeRequest.VacationID);
            return employeeRequest.Days > (vacationview.Balance - (vacationview.Used - currval));
        }
    }
}
