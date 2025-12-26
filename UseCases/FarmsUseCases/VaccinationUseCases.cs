using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using System.Collections.Generic;

namespace UseCases.FarmsUseCases
{
    public interface IViewVaccinationsUseCase { IEnumerable<Vaccination> Execute(); }
    public class ViewVaccinationsUseCase : IViewVaccinationsUseCase
    {
        private readonly IVaccinationRepository _repo;
        public ViewVaccinationsUseCase(IVaccinationRepository repo) => _repo = repo;
        public IEnumerable<Vaccination> Execute() => _repo.GetVaccinations();
    }

    // --- MỚI: Logic Thêm lịch tiêm ---
    public interface IAddVaccinationUseCase { void Execute(Vaccination vaccination); }
    public class AddVaccinationUseCase : IAddVaccinationUseCase
    {
        private readonly IVaccinationRepository _repo;
        public AddVaccinationUseCase(IVaccinationRepository repo) => _repo = repo;
        public void Execute(Vaccination v) => _repo.AddVaccination(v);
    }

    public interface ICompleteVaccinationUseCase { void Execute(int id); }
    public class CompleteVaccinationUseCase : ICompleteVaccinationUseCase
    {
        private readonly IVaccinationRepository _vRepo;
        private readonly ISupplyRepository _sRepo;
        public CompleteVaccinationUseCase(IVaccinationRepository vRepo, ISupplyRepository sRepo)
        {
            _vRepo = vRepo; _sRepo = sRepo;
        }
        public void Execute(int id)
        {
            var v = _vRepo.GetVaccinationById(id);
            if (v != null && !v.IsCompleted)
            {
                v.IsCompleted = true;
                v.AdministeredDate = System.DateTime.Now;
                _vRepo.UpdateVaccination(v);
                var s = _sRepo.GetSupplyById(v.SupplyId);
                if (s != null) { s.Quantity -= 1; _sRepo.UpdateSupply(s); }
            }
        }
    }
}