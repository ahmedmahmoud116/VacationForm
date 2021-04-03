using System.Collections.Generic;
using System.Linq;
using Model.Models;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryInterface;
using Data.Factory;
using Data.DBContexts;

namespace Repository.Repo
{
    public class EmployeeBalanceRepository: IEmployeeBalanceRepository
    {
        private readonly IDbFactory dbFactory;
        private readonly VacationContext _context;

        public EmployeeBalanceRepository(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            this._context = dbFactory.init();
        }
        public VacationContext context
        {
            get { return _context == null ? dbFactory.init() : _context; }
        }

        public void AddEmployeeBalance(EmployeeBalance employeeBalance)
        {
            context.Add(employeeBalance);
            //_context.SaveChanges();
        }

        public EmployeeBalance DeleteEmployeeBalance(int id)
        {
            EmployeeBalance employeeBalance = GetEmployeeBalance(id);
            context.Remove(employeeBalance);
            //context.SaveChanges();
            return employeeBalance;
        }

        public List<EmployeeBalance> GetAllEmployeeBalances()
        {
            return context.EmployeeBalances.ToList();
        }

        public EmployeeBalance GetEmployeeBalance(int id)
        {
            return context.EmployeeBalances.SingleOrDefault(e => e.ID == id);
        }

        public void UpdateEmployeeBalance(EmployeeBalance employeeBalance)
        {
            context.Update(employeeBalance);
            //context.SaveChanges();
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
