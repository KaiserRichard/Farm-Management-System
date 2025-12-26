using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.FarmsUseCases
{
    public interface IGetFarmByIdUseCase
    {
        Farm? Execute(int farmId);
    }

    public class GetFarmByIdUseCase : IGetFarmByIdUseCase
    {
        private readonly IFarmRepository _farmRepository;
        public GetFarmByIdUseCase(IFarmRepository farmRepository) => _farmRepository = farmRepository;
        public Farm? Execute(int farmId) => _farmRepository.GetFarmById(farmId);
    }

    public interface IEditFarmUseCase
    {
        void Execute(Farm farm);
    }

    public class EditFarmUseCase : IEditFarmUseCase
    {
        private readonly IFarmRepository _farmRepository;
        public EditFarmUseCase(IFarmRepository farmRepository) => _farmRepository = farmRepository;
        public void Execute(Farm farm) => _farmRepository.UpdateFarm(farm);
    }
}