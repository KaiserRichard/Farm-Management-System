using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.Administrative
{
    public class AddCommuneUseCase
    {
        private readonly ICommuneRepository repository;

        public AddCommuneUseCase(ICommuneRepository repository)
        {
            this.repository = repository;
        }

        public async Task ExecuteAsync(Commune commune)
        {
            if (string.IsNullOrWhiteSpace(commune.Name))
                throw new ArgumentException("Commune name is required");

            await repository.AddAsync(commune);
        }
    }
}
