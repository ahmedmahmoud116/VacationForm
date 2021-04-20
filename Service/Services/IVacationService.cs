using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;
using Microsoft.EntityFrameworkCore;
namespace Service.Services
{
    public interface IVacationService
    {
        void AddVacation(Vacation vacation); //to add vacation
        List<Vacation> GetAllVacations();
        Vacation GetVacation(int id);
        Vacation DeleteVacation(int id);
        void UpdateVacation(Vacation vacation); //to edit vacation
        public void StateVacation(Vacation vacation, EntityState state); //to return state of Vacation
        public void SaveVacation(); //to save changes in the db
        public bool VacationExists(int id); //in service only

        public bool VacationValidationPost(Vacation vacation);//to validate post validations

        public bool VacationValidationEdit(Vacation vacation);//to validate edit validations
    }
}
