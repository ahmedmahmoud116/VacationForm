using System;
using System.Collections.Generic;
using System.Text;
using Service.Services;
using Repository.RepositoryInterface;
using Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Service.Serv
{
    public class EmployeeBalanceService : IEmployeeBalanceService
    {
        private readonly IEmployeeBalanceRepository _employeeBalanceRepo;

        public EmployeeBalanceService(IEmployeeBalanceRepository employeeBalanceRepository)
        {
            this._employeeBalanceRepo = employeeBalanceRepository;
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
    }
}
