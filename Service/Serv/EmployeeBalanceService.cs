using System;
using System.Collections.Generic;
using System.Text;
using Service.Services;
using Repository.RepositoryInterface;
using Model.Models;

namespace Service.Serv
{
    class EmployeeBalanceService : IEmployeeBalanceService
    {
        private readonly IEmployeeBalanceRepository _employeeBalanceRepo;

        public EmployeeBalanceService(IEmployeeBalanceRepository employeeBalanceRepository)
        {
            this._employeeBalanceRepo = employeeBalanceRepository;
        }

        public void CreateEmployeeBalance(EmployeeBalance employeeBalance)
        {
            _employeeBalanceRepo.CreateEmployeeBalance(employeeBalance);
        }

        public void DeleteEmployeeBalance(int id)
        {
            _employeeBalanceRepo.DeleteEmployeeBalance(id);
        }

        public List<EmployeeBalance> GetAllEmployeeBalances()
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
    }
}
