using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DBContexts;
using Model.Models;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryInterface;

namespace Repository.Repo
{
    public class EmployeeRequestRepository : IEmployeeRequestRepository
    {
        private VacationContext context;
        private DbSet<EmployeeRequest> employeeRequestEntity;

        public EmployeeRequestRepository(VacationContext context)
        {
            this.context = context;
            employeeRequestEntity = context.Set<EmployeeRequest>();
        }
        public void CreateEmployeeRequest(EmployeeRequest employeeRequest)
        {
            employeeRequestEntity.Add(employeeRequest);
            context.SaveChanges();
        }

        public void DeleteEmployeeRequest(int id)
        {
            EmployeeRequest employeeRequest = GetEmployeeRequest(id);
            employeeRequestEntity.Remove(employeeRequest);
            context.SaveChanges();
        }

        public List<EmployeeRequest> GetAllEmployeeRequests()
        {
            return employeeRequestEntity.ToList();
        }

        public EmployeeRequest GetEmployeeRequest(int id)
        {
            return employeeRequestEntity.SingleOrDefault(e => e.ID == id);
        }

        public void UpdateEmployeeRequest(EmployeeRequest employeeRequest)
        {
            employeeRequestEntity.Update(employeeRequest);
            context.SaveChanges();
        }
    }
}
