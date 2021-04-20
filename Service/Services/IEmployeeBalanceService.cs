using System.Collections.Generic;
using Model.Models;
using Microsoft.EntityFrameworkCore;
namespace Service.Services
{
    public interface IEmployeeBalanceService
    {
        void AddEmployeeBalance(EmployeeBalance employeeBalance); //to add EmployeeBalance
        //List<EmployeeBalance> GetAllEmployeeBalances();
        List<VacationView> GetAllEmployeeBalances();
        EmployeeBalance GetEmployeeBalance(int id);
        EmployeeBalance DeleteEmployeeBalance(int id);
        void UpdateEmployeeBalance(EmployeeBalance employeeBalance); //to edit EmployeeBalance
        void UpdateEmployeeBalances(VacationView[] vacationViewArrays);//to update bulk of employeebalances
        public void StateEmployeeBalance(EmployeeBalance employeeBalance, EntityState state); //to return state of employee
        public void SaveEmployeeBalance(); //to save changes in the db
        public bool EmployeeBalanceExists(int id); //in service only
        public bool EmployeebalanceValidationPost(EmployeeBalance employeeBalance);//to validate employeebalance post request
        public bool EmployeebalanceValidationEdit(EmployeeBalance employeeBalance);//to validate employeebalance put request
    }
}
