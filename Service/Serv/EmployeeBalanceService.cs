using System.Collections.Generic;
using Service.Services;
using Repository.RepositoryInterface;
using Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Service.Serv
{
    public class EmployeeBalanceService : IEmployeeBalanceService
    {
        private readonly IEmployeeBalanceRepository _employeeBalanceRepo;
        private readonly IVacationRepository _vacationRepo;

        public EmployeeBalanceService(IEmployeeBalanceRepository employeeBalanceRepository, IVacationRepository vacationRepository)
        {
            this._employeeBalanceRepo = employeeBalanceRepository;
            this._vacationRepo = vacationRepository;
        }

        public void AddEmployeeBalance(EmployeeBalance employeeBalance)
        {
            _employeeBalanceRepo.AddEmployeeBalance(employeeBalance);
        }

        public EmployeeBalance DeleteEmployeeBalance(int id)
        {
            return _employeeBalanceRepo.DeleteEmployeeBalance(id);
        }

        //public List<EmployeeBalance> GetAllEmployeeBalances()
        //{
        //    return _employeeBalanceRepo.GetAllEmployeeBalances();
        //}
        public List<VacationView> GetAllEmployeeBalances()
        {
            return _employeeBalanceRepo.GetAllEmployeeBalances();
        }

        public EmployeeBalance GetEmployeeBalance(int id)
        {
            return _employeeBalanceRepo.GetEmployeeBalance(id);
        }

        public void UpdateEmployeeBalance(EmployeeBalance employeeBalance)
        {
            _employeeBalanceRepo.UpdateEmployeeBalance(employeeBalance);
        }

        public void UpdateEmployeeBalances(VacationView[] vacationViewArrays)
        {
            _employeeBalanceRepo.UpdateEmployeeBalances(vacationViewArrays);
        }

        public void StateEmployeeBalance(EmployeeBalance employeeBalance, EntityState state)
        {
            _employeeBalanceRepo.StateEmployeeBalance(employeeBalance, state);
        }
        public void SaveEmployeeBalance()
        {
            _employeeBalanceRepo.SaveEmployeeBalance();
        }

        public bool EmployeeBalanceExists(int id)
        {
            return _employeeBalanceRepo.GetEmployeeBalance(id) == null ? false : true;
        }
        public bool EmployeebalanceValidationPost(EmployeeBalance employeeBalance)
        {
            return positiveValidator(employeeBalance.Balance) || checkVacaionBalance(employeeBalance) || EmployeeBalanceExists(employeeBalance);
        }

        public bool EmployeebalanceValidationEdit(EmployeeBalance employeeBalance)
        {
            return positiveValidator(employeeBalance.Balance) || checkVacaionBalance(employeeBalance);
        }

        private bool positiveValidator(int number)
        {
            Regex regex = new Regex(@"^[1-9]+[0-9]*$");
            Match match = regex.Match(number.ToString());
            return !match.Success;
        }

        private bool checkVacaionBalance(EmployeeBalance employeeBalance)
        {
            return employeeBalance.Balance > _vacationRepo.GetVacation(employeeBalance.VacationID).Balance;   
        }

        public bool EmployeeBalanceExists(EmployeeBalance employeeBalance)
        {
            List<VacationView> vacationViews = _employeeBalanceRepo.GetAllEmployeeBalances();
            var vacation = vacationViews.Find(v => v.employeeID == employeeBalance.EmployeeID && v.vacationID == employeeBalance.VacationID);
            return vacation != null;
        }

    }
}
