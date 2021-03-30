using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.RepositoryInterface
{
    public interface IVacationRepository
    {
        void AddVacation(Vacation vacation); //to add vacation
        List<Vacation> GetAllVacations();
        Vacation GetVacation(int id);
        Vacation DeleteVacation(int id);
        void UpdateVacation(Vacation vacation); //to edit vacation
        public void StateVacation(Vacation vacation, EntityState state); //to return state of vacation
        public void SaveVacation(); //to save changes in the db
    }
}
