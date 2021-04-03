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
    public class VacationRepository: IVacationRepository
    {
        private readonly IDbFactory dbFactory;
        private readonly VacationContext _context;

        public VacationRepository(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            this._context = dbFactory.init();
        }
        public VacationContext context
        {
            get { return _context == null ? dbFactory.init() : _context; }
        }


        public void AddVacation(Vacation vacation)
        {
            context.Add(vacation);
            //context.SaveChanges();
        }

        public Vacation DeleteVacation(int id)
        {
            Vacation vacation = GetVacation(id);
            context.Remove(vacation);
            //context.SaveChanges();
            return vacation;
        }
        public List<Vacation> GetAllVacations()
        {
            return context.Vacations.ToList();
        }

        public Vacation GetVacation(int id)
        {
            return context.Vacations.SingleOrDefault(e => e.ID == id);
        }

        public void UpdateVacation(Vacation vacation)
        {
            context.Update(vacation);
            //context.SaveChanges();
        }
        public void StateVacation(Vacation vacation, EntityState state)
        {
            context.Entry(vacation).State = state;
        }
        public void SaveVacation()
        {
            context.SaveChangesAsync();
        }
    }
}
