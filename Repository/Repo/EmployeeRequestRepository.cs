using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryInterface;
using Data.Factory;
using Data.DBContexts;

namespace Repository.Repo
{
    public class EmployeeRequestRepository : IEmployeeRequestRepository
    {
        private readonly IDbFactory dbFactory;
        private readonly VacationContext _context;

        public EmployeeRequestRepository(IDbFactory dbfactory)
        {
            this.dbFactory = dbfactory;
            this._context = dbFactory.init();
        }
        public VacationContext context
        {
            get { return _context == null ? dbFactory.init() : _context; }
        }


        public void AddEmployeeRequest(EmployeeRequest employeeRequest)
        {
            context.Add(employeeRequest);
            //context.SaveChanges();
        }

        public EmployeeRequest DeleteEmployeeRequest(int id)
        {
            EmployeeRequest employeeRequest = GetEmployeeRequest(id);
            context.Remove(employeeRequest);
            //context.SaveChanges();
            return employeeRequest;
        }

        public List<VacationRequestView> GetAllEmployeeRequests()
        {
            var query = from e in context.Employees
                        join er in context.EmployeeRequests on e.ID equals er.EmployeeID
                        join v in context.Vacations on er.VacationID equals v.ID into group1
                        from g1 in group1.DefaultIfEmpty()
                        select new VacationRequestView { ID = er.ID, employeeID = e.ID, FullName = e.FullName, vacationID = g1.ID, Type = g1.Type, Days = er.Days};

            List<VacationRequestView> employeevacations = query.ToList();
            //employeevacations = employeevacations.GroupBy(v => new
            //{
            //    v.employeeID,
            //    v.vacationID
            //})
            //    .Select(g => new VacationView()
            //    {
            //        ID = g.FirstOrDefault().ID,
            //        vacationID = g.Key.vacationID,
            //        employeeID = g.Key.employeeID,
            //        Type = g.FirstOrDefault().Type,
            //        FullName = g.FirstOrDefault().FullName,
            //        Balance = g.FirstOrDefault().Balance,
            //        Used = g.Sum(u => u.Used)
            //    }).ToList();

            return employeevacations;
            //return context.EmployeeRequests.ToList();
        }

        public EmployeeRequest GetEmployeeRequest(int id)
        {
            return context.EmployeeRequests.SingleOrDefault(e => e.ID == id);
        }

        public void UpdateEmployeeRequest(EmployeeRequest employeeRequest)
        {
            context.Update(employeeRequest);
            //_context.SaveChanges();
        }

        public void StateEmployeeRequest(EmployeeRequest employeeRequest, EntityState state)
        {
            context.Entry(employeeRequest).State = state;
        }
        public void SaveEmployeeRequest()
        {
            context.SaveChangesAsync();
        }
    }
}
