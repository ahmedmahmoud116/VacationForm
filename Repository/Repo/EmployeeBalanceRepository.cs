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
        //private IDbFactory dbFactory;
        private VacationContext _context;
        private DbSet<EmployeeBalance> _employeeBalanceEntity;

        public EmployeeBalanceRepository(VacationContext context)
        {
            //this.dbFactory = dbFactory;
            this._context = context;
            _employeeBalanceEntity = _context.Set<EmployeeBalance>();
        }
        //public VacationContext context
        //{
        //    get { return _context == null ? dbFactory.init() : _context; }
        //}

        //public DbSet<EmployeeBalance> employeeBalanceEntity
        //{
        //    set { _employeeBalanceEntity = context.Set<EmployeeBalance>(); }
        //}

        public void AddEmployeeBalance(EmployeeBalance employeeBalance)
        {
            _employeeBalanceEntity.Add(employeeBalance);
            _context.SaveChanges();
        }

        public EmployeeBalance DeleteEmployeeBalance(int id)
        {
            EmployeeBalance employeeBalance = GetEmployeeBalance(id);
            _employeeBalanceEntity.Remove(employeeBalance);
            //context.SaveChanges();
            return employeeBalance;
        }

        public List<EmployeeBalance> GetAllEmployeeBalances()
        {
            return _employeeBalanceEntity.ToList();
        }

        public EmployeeBalance GetEmployeeBalance(int id)
        {
            return _employeeBalanceEntity.SingleOrDefault(e => e.ID == id);
        }

        public void UpdateEmployeeBalance(EmployeeBalance employeeBalance)
        {
            _employeeBalanceEntity.Update(employeeBalance);
            //context.SaveChanges();
        }
        public void StateEmployeeBalance(EmployeeBalance employeeBalance, EntityState state)
        {
            _context.Entry(employeeBalance).State = state;
        }
        public void SaveEmployeeBalance()
        {
            _context.SaveChangesAsync();
        }
    }
}
