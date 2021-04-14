using System.Collections.Generic;
using Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.RepositoryInterface
{
    public interface IEmployeeBalanceRepository
    {
        void AddEmployeeBalance(EmployeeBalance employeeBalance); //to add EmployeeBalance
        //List<EmployeeBalance> GetAllEmployeeBalances();
        List<VacationView> GetAllEmployeeBalances();
        EmployeeBalance GetEmployeeBalance(int id);
        EmployeeBalance DeleteEmployeeBalance(int id);
        void UpdateEmployeeBalance(EmployeeBalance employeeBalance); //to edit EmployeeBalance

        void UpdateEmployeeBalances(VacationView[] vacationViewArrays);//to update bulk of employee balances
        public void StateEmployeeBalance(EmployeeBalance employeeBalance, EntityState state); //to return state of EmployeeBalance
        public void SaveEmployeeBalance(); //to save changes in the db
    }
}
