using System.Collections.Generic;
using Service.Services;
using Repository.RepositoryInterface;
using Model.Models;
using Microsoft.EntityFrameworkCore;
using UnitOfWorks.Interfaces;
using System.Text.RegularExpressions;

namespace Service.Serv
{
    public class VacationService : IVacationService
    {
        private readonly IVacationRepository _vacationRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IEmployeeBalanceRepository _employeeBalanceRepo;

        public VacationService(IUnitOfWork unitOfWork, 
                               IVacationRepository vacationRepository,
                               IEmployeeRepository employeeRepository,
                               IEmployeeBalanceRepository employeeBalanceRepository)
        {
            this._unitOfWork = unitOfWork;
            this._vacationRepo = vacationRepository;
            this._employeeRepo = employeeRepository;
            this._employeeBalanceRepo = employeeBalanceRepository;
        }

        public void AddVacation(Vacation vacation)
        {
            _vacationRepo.AddVacation(vacation);

            List<Employee> employees = _employeeRepo.GetAllEmployees();
            foreach(Employee employee in employees)
            {
                EmployeeBalance employeeBalance = new EmployeeBalance
                {
                    Employee = employee,
                    Vacation = vacation,
                    Balance = vacation.Balance
                };
                _employeeBalanceRepo.AddEmployeeBalance(employeeBalance);
            }
        }

        public Vacation DeleteVacation(int id)
        {
           return _vacationRepo.DeleteVacation(id);
        }

        public List<Vacation> GetAllVacations()
        {
            return _vacationRepo.GetAllVacations();
        }

        public Vacation GetVacation(int id)
        {
            return _vacationRepo.GetVacation(id);
        }

        public void UpdateVacation(Vacation vacation)
        {
            _vacationRepo.UpdateVacation(vacation);
        }
        public void StateVacation(Vacation vacation, EntityState state)
        {
            _vacationRepo.StateVacation(vacation, state);
        }
        public void SaveVacation()
        {
            _unitOfWork.Commit();
        }

        public bool VacationExists(int id)
        {
            return _vacationRepo.GetVacation(id) == null ? false : true;
        }
        
        public bool VacationValidationPost(Vacation vacation)
        {
            return positiveValidator(vacation.Balance) || vacation.Balance > 200; //to limit balance to 200 || vacationExist(vacation.Type)
        }

        public bool VacationValidationEdit(Vacation vacation)
        {
            return positiveValidator(vacation.Balance) || vacation.Balance > 200; //to limit balance to 200
        }

        private bool positiveValidator(int number)
        {
            Regex regex = new Regex(@"^[1-9]+[0-9]*$");
            Match match = regex.Match(number.ToString());
            return !match.Success;
        }

        private bool vacationExist(string vacationType)
        {
            List<Vacation> vacations = _vacationRepo.GetAllVacations();
            var vac = vacations.Find(v => v.Type == vacationType);
            return vac != null;
        }
    }
}
