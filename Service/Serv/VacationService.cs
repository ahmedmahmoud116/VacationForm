using System.Collections.Generic;
using Service.Services;
using Repository.RepositoryInterface;
using Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Service.Serv
{
    public class VacationService : IVacationService
    {
        private readonly IVacationRepository _vacationRepo;

        public VacationService(IVacationRepository vacationRepository)
        {
            this._vacationRepo = vacationRepository;
        }

        public void AddVacation(Vacation vacation)
        {
            _vacationRepo.AddVacation(vacation);
        }

        public Vacation DeleteVacation(int id)
        {
           return _vacationRepo.DeleteVacation(id);
        }

        public List<Vacation> GetAllVacations()
        {
            return _vacationRepo.GetAllVacations();
        }

        public Vacation GetVacation(int id)
        {
            return _vacationRepo.GetVacation(id);
        }

        public void UpdateVacation(Vacation vacation)
        {
            _vacationRepo.UpdateVacation(vacation);
        }
        public void StateVacation(Vacation vacation, EntityState state)
        {
            _vacationRepo.StateVacation(vacation, state);
        }
        public void SaveVacation()
        {
            _vacationRepo.SaveVacation();
        }

        public bool VacationExists(int id)
        {
            return _vacationRepo.GetVacation(id) == null ? false : true;
        }
    }
}
