﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;
using Microsoft.EntityFrameworkCore;
namespace Service.Services
{
    public interface IEmployeeBalanceService
    {
        void AddEmployeeBalance(EmployeeBalance employeeBalance); //to add EmployeeBalance
        List<EmployeeBalance> GetAllEmployeeBalances();
        EmployeeBalance GetEmployeeBalance(int id);
        EmployeeBalance DeleteEmployeeBalance(int id);
        void UpdateEmployeeBalance(EmployeeBalance employeeBalance); //to edit EmployeeBalance
        public void StateEmployeeBalance(EmployeeBalance employeeBalance, EntityState state); //to return state of employee
        public void SaveEmployeeBalance(); //to save changes in the db
        public bool EmployeeBalanceExists(int id); //in service only
    }
}