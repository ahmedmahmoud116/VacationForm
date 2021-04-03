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
        //private IDbFactory dbFactory;
        private VacationContext _context;
        private DbSet<EmployeeRequest> _employeeRequestEntity;

        public EmployeeRequestRepository(VacationContext context)
        {
            //this.dbFactory = dbFactory;
            this._context = context;
            _employeeRequestEntity = _context.Set<EmployeeRequest>();
        }
        //public VacationContext context
        //{
        //    get { return _context == null ? dbFactory.init() : _context; }
        //}

        //public DbSet<EmployeeRequest> employeeRequestEntity
        //{
        //    set { _employeeRequestEntity = context.Set<EmployeeRequest>(); }
        //}

        public void AddEmployeeRequest(EmployeeRequest employeeRequest)
        {
            _employeeRequestEntity.Add(employeeRequest);
            //context.SaveChanges();
        }

        public EmployeeRequest DeleteEmployeeRequest(int id)
        {
            EmployeeRequest employeeRequest = GetEmployeeRequest(id);
            _employeeRequestEntity.Remove(employeeRequest);
            //context.SaveChanges();
            return employeeRequest;
        }

        public List<EmployeeRequest> GetAllEmployeeRequests()
        {
            return _employeeRequestEntity.ToList();
        }

        public EmployeeRequest GetEmployeeRequest(int id)
        {
            return _employeeRequestEntity.SingleOrDefault(e => e.ID == id);
        }

        public void UpdateEmployeeRequest(EmployeeRequest employeeRequest)
        {
            _employeeRequestEntity.Update(employeeRequest);
            //_context.SaveChanges();
        }

        public void StateEmployeeRequest(EmployeeRequest employeeRequest, EntityState state)
        {
            _context.Entry(employeeRequest).State = state;
        }
        public void SaveEmployeeRequest()
        {
            _context.SaveChangesAsync();
        }
    }
}
