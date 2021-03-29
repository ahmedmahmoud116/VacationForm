using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationForm.DBContexts;
using VacationForm.Models;
using Microsoft.EntityFrameworkCore;
using VacationForm.RepositoryInterface;

namespace VacationForm.Repository
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
        public void CreateVacation(Vacation vacation)
        {
            vacationEntity.Add(vacation);
            context.SaveChanges();
        }

        public void DeleteVacation(int id)
        {
            Vacation vacation = GetVacation(id);
            vacationEntity.Remove(vacation);
            context.SaveChanges();
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
    }
}
