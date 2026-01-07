using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.Administrative
{
    public class ViewDistrictsUseCase
    {
        private readonly IDistrictRepository repository;

        public ViewDistrictsUseCase(IDistrictRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<District>> ExecuteAsync()
        {
            return await repository.GetAllAsync();
        }
    }
}
