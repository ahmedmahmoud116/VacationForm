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
    public class VacationRepository: IVacationRepository
    {
        private VacationContext context;
        private DbSet<Vacation> vacationEntity;

        public VacationRepository(VacationContext context)
        {
            this.context = context;
            vacationEntity = context.Set<Vacation>();
        }
        public void AddVacation(Vacation vacation)
        {
            vacationEntity.Add(vacation);
            context.SaveChanges();
        }

        public Vacation DeleteVacation(int id)
        {
            Vacation vacation = GetVacation(id);
            vacationEntity.Remove(vacation);
            context.SaveChanges();
            return vacation;
        }
        public List<Vacation> GetAllVacations()
        {
            return vacationEntity.ToList();
        }

        public Vacation GetVacation(int id)
        {
            return vacationEntity.SingleOrDefault(e => e.ID == id);
        }

        public void UpdateVacation(Vacation vacation)
        {
            vacationEntity.Update(vacation);
            context.SaveChanges();
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
