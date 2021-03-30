using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.RepositoryInterface
{
    public interface IEmployeeBalanceRepository
    {
        void AddEmployeeBalance(EmployeeBalance employeeBalance); //to add EmployeeBalance
        List<EmployeeBalance> GetAllEmployeeBalances();
        EmployeeBalance GetEmployeeBalance(int id);
        EmployeeBalance DeleteEmployeeBalance(int id);
        void UpdateEmployeeBalance(EmployeeBalance employeeBalance); //to edit EmployeeBalance
        public void StateEmployeeBalance(EmployeeBalance employeeBalance, EntityState state); //to return state of EmployeeBalance
        public void SaveEmployeeBalance(); //to save changes in the db
    }
}
