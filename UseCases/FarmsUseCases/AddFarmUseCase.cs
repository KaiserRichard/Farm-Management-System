using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.FarmsUseCases
{
    // BẮT BUỘC PHẢI CÓ DÒNG NÀY
    public interface IAddFarmUseCase
    {
        void Execute(Farm farm);
    }

    public class AddFarmUseCase : IAddFarmUseCase
    {
        private readonly IFarmRepository _farmRepository;

        public AddFarmUseCase(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository;
        }

        public void Execute(Farm farm)
        {
            _farmRepository.AddFarm(farm);
        }
    }
}