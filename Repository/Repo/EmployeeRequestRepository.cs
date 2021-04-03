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

        public List<EmployeeRequest> GetAllEmployeeRequests()
        {
            return context.EmployeeRequests.ToList();
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
