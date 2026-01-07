using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.Administrative
{
    public class ViewCommunesUseCase
    {
        private readonly ICommuneRepository repository;

        public ViewCommunesUseCase(ICommuneRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Commune>> ExecuteAsync()
        {
            return await repository.GetAllAsync();
        }
    }
}
