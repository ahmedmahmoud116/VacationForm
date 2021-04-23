using System.Collections.Generic;
using Service.Services;
using Repository.RepositoryInterface;
using Model.Models;
using Microsoft.EntityFrameworkCore;
using UnitOfWorks.Interfaces;
using System;

namespace Service.Serv
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository employeeRepository;
        private readonly IUnitOfWork unitOfWork;
        private IVacationRepository vacationRepository;
        private IEmployeeBalanceRepository employeeBalanceRepository;

        public EmployeeService(IUnitOfWork unitOfWork, 
                               IEmployeeRepository employeeRepository, 
                               IVacationRepository vacationRepository,
                               IEmployeeBalanceRepository employeeBalanceRepository)
        {
            this.unitOfWork = unitOfWork;
            this.employeeRepository = employeeRepository;
            this.vacationRepository = vacationRepository;
            this.employeeBalanceRepository = employeeBalanceRepository;
        }

        public void AddEmployee(Employee employee)
        {
            employeeRepository.AddEmployee(employee);

            List<Vacation> vacations = vacationRepository.GetAllVacations(); //get vacation list of all our vacation

            foreach (Vacation vacation in vacations)//loop in each one of them and add employee to each vacation with its default value
            { 
                EmployeeBalance employeeBalance = new EmployeeBalance();
                employeeBalance.Employee = employee;
                employeeBalance.Vacation = vacation;
                employeeBalance.Balance = vacation.Balance;
                employeeBalanceRepository.AddEmployeeBalance(employeeBalance);
            }
    }

        public Employee DeleteEmployee(int id)
        {
            return employeeRepository.DeleteEmployee(id);
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAllEmployees();
        }

        public Employee GetEmployee(int id)
        {
            return employeeRepository.GetEmployee(id);
        }
        public Employee GetEmployee(string name)
        {
            return employeeRepository.GetEmployee(name);
        }

        public void UpdateEmployee(Employee employee)
        {
            employeeRepository.UpdateEmployee(employee);
        }

        public void StateEmployee(Employee employee, EntityState state)
        {
            employeeRepository.StateEmployee(employee, state);
        }

        public void SaveEmployee()
        {
            //employeeRepository.SaveEmployee();
            unitOfWork.Commit();
        }

        public bool EmployeeExists(int id)
        {
            return employeeRepository.GetEmployee(id) == null ? false : true;
        }
        public bool EmployeeExists(string FullName)
        {
            return employeeRepository.GetEmployee(FullName) == null ? false : true;
        }
    }
}
