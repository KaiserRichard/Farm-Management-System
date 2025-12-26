using UseCases.DataStorePluginInterfaces;

namespace UseCases.FarmsUseCases
{
    // BẮT BUỘC PHẢI CÓ DÒNG NÀY
    public interface IDeleteFarmUseCase
    {
        void Execute(int farmId);
    }

    public class DeleteFarmUseCase : IDeleteFarmUseCase
    {
        private readonly IFarmRepository _farmRepository;

        public DeleteFarmUseCase(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository;
        }

        public void Execute(int farmId)
        {
            _farmRepository.DeleteFarm(farmId);
        }
    }
}