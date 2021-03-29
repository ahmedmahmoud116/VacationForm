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
    public class EmployeeBalanceRepository: IEmployeeBalanceRepository
    {
        private VacationContext context;
        private DbSet<EmployeeBalance> employeeBalanceEntity;

        public EmployeeBalanceRepository(VacationContext context)
        {
            this.context = context;
            employeeBalanceEntity = context.Set<EmployeeBalance>();
        }
        public void CreateEmployeeBalance(EmployeeBalance employeeBalance)
        {
            employeeBalanceEntity.Add(employeeBalance);
            context.SaveChanges();
        }

        public void DeleteEmployeeBalance(int id)
        {
            EmployeeBalance employeeBalance = GetEmployeeBalance(id);
            employeeBalanceEntity.Remove(employeeBalance);
            context.SaveChanges();
        }

        public List<EmployeeBalance> GetAllEmployeeBalances()
        {
            return employeeBalanceEntity.ToList();
        }

        public EmployeeBalance GetEmployeeBalance(int id)
        {
            return employeeBalanceEntity.SingleOrDefault(e => e.ID == id);
        }

        public void UpdateEmployeeBalance(EmployeeBalance employeeBalance)
        {
            employeeBalanceEntity.Update(employeeBalance);
            context.SaveChanges();
        }
    }
}
