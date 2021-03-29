using System.Collections.Generic;
using Service.Services;
using Repository.RepositoryInterface;
using Model.Models;

namespace Service.Serv
{
    class VacationService : IVacationService
    {
        private readonly IVacationRepository _vacationRepo;

        public VacationService(IVacationRepository vacationRepository)
        {
            this._vacationRepo = vacationRepository;
        }

        public void CreateVacation(Vacation vacation)
        {
            _vacationRepo.CreateVacation(vacation);
        }

        public void DeleteVacation(int id)
        {
            _vacationRepo.DeleteVacation(id);
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
    }
}
