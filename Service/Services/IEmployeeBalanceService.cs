using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;

namespace Service.Services
{
    public interface IEmployeeBalanceService
    {
        void CreateEmployeeBalance(EmployeeBalance employeeBalance); //to add EmployeeBalance
        List<EmployeeBalance> GetAllEmployeeBalances();
        EmployeeBalance GetEmployeeBalance(int id);
        void DeleteEmployeeBalance(int id);
        void UpdateEmployeeBalance(EmployeeBalance employeeBalance); //to edit EmployeeBalance
    }
}
