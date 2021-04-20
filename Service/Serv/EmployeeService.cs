using System.Collections.Generic;
using Service.Services;
using Repository.RepositoryInterface;
using Model.Models;
using Microsoft.EntityFrameworkCore;
using UnitOfWorks.Interfaces;

namespace Service.Serv
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository employeeRepository;
        private readonly IUnitOfWork unitOfWork;
        private IVacationRepository vacationRepository;

        public EmployeeService(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository, IVacationRepository vacationRepository)
        {
            this.unitOfWork = unitOfWork;
            this.employeeRepository = employeeRepository;
            this.vacationRepository = vacationRepository;
        }

        public void AddEmployee(Employee employee)
        {
            employeeRepository.AddEmployee(employee);

            List<Vacation> vacations = vacationRepository.GetAllVacations();
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
