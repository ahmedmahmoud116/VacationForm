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

        //public List<EmployeeBalance> GetAllEmployeeBalances(){}
        public List<VacationView> GetAllEmployeeBalances()
        {
            var query = from e in context.Employees
                        join eb in context.EmployeeBalances on e.ID equals eb.EmployeeID
                        join v in context.Vacations on eb.VacationID equals v.ID into group2
                        from g2 in group2.DefaultIfEmpty()
                        join er in context.EmployeeRequests on new { eb.EmployeeID, eb.VacationID }
                                                            equals new { er.EmployeeID, er.VacationID } into group3
                        from g3 in group3.DefaultIfEmpty()
                        orderby e.FullName
                        select new VacationView {ID = eb.ID, employeeID = e.ID, FullName = e.FullName, vacationID= g2.ID, Type = g2.Type, Balance = eb.Balance, Used = g3.Days };

            List<VacationView> employeevacations = query.ToList();
            employeevacations = employeevacations.GroupBy(v => new
            {
                v.employeeID,
                v.vacationID
            })
                .Select(g => new VacationView()
                {
                    ID = g.FirstOrDefault().ID,
                    vacationID = g.Key.vacationID,
                    employeeID = g.Key.employeeID,
                    Type = g.FirstOrDefault().Type,
                    FullName = g.FirstOrDefault().FullName,
                    Balance = g.FirstOrDefault().Balance,
                    Used = g.Sum(u => u.Used)
                }).ToList();

            return employeevacations;
            //return context.EmployeeBalances.ToList();
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
        
        public void UpdateEmployeeBalances(VacationView[] vacationViewArrays) 
        { 
            foreach(VacationView vacationView in vacationViewArrays){
                EmployeeBalance eb = new EmployeeBalance();
                eb = context.EmployeeBalances.SingleOrDefault(e => e.ID == vacationView.ID);
                if (eb != null)
                {
                    //eb.EmployeeID = vacationView.employeeID;
                    //eb.VacationID = vacationView.vacationID;
                    eb.Balance = vacationView.Balance;
                }
                //context.Update(vacationView);
            }
        }
    }
}
