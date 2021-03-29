using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationForm.Models;

namespace VacationForm.RepositoryInterface
{
    public interface IVacationRepository
    {
        void CreateVacation(Vacation vacation); //to add vacation
        List<Vacation> GetAllVacations();
        Vacation GetVacation(int id);
        void DeleteVacation(int id);
        void UpdateVacation(Vacation vacation); //to edit vacation
    }
}
