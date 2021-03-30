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
        public void AddEmployeeBalance(EmployeeBalance employeeBalance)
        {
            employeeBalanceEntity.Add(employeeBalance);
            context.SaveChanges();
        }

        public EmployeeBalance DeleteEmployeeBalance(int id)
        {
            EmployeeBalance employeeBalance = GetEmployeeBalance(id);
            employeeBalanceEntity.Remove(employeeBalance);
            context.SaveChanges();
            return employeeBalance;
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
        public void StateEmployeeBalance(EmployeeBalance employeeBalance, EntityState state)
        {
            context.Entry(employeeBalance).State = state;
        }
        public void SaveEmployeeBalance()
        {
            context.SaveChangesAsync();
        }
    }
}
