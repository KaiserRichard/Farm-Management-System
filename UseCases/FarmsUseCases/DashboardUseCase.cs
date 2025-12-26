using UseCases.DataStorePluginInterfaces;
using System.Linq;

namespace UseCases.FarmsUseCases
{
    public interface IDashboardUseCase { (int TotalAnimals, int PendingVaccines, int LowStock) Execute(); }

    public class DashboardUseCase : IDashboardUseCase
    {
        private readonly IAnimalRepository _animalRepo;
        private readonly IVaccinationRepository _vaccineRepo;
        private readonly ISupplyRepository _supplyRepo;

        public DashboardUseCase(IAnimalRepository animalRepo, IVaccinationRepository vaccineRepo, ISupplyRepository supplyRepo)
        {
            _animalRepo = animalRepo;
            _vaccineRepo = vaccineRepo;
            _supplyRepo = supplyRepo;
        }

        public (int, int, int) Execute() => (
            _animalRepo.GetAnimals().Count(),
            _vaccineRepo.GetVaccinations().Count(v => !v.IsCompleted), // Đếm lịch tiêm đang chờ
            _supplyRepo.GetSupplies().Count(s => s.Quantity < 10)     // Cảnh báo khi số lượng < 10
        );
    }
}