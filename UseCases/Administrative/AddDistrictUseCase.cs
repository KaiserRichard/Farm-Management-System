using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.Administrative
{
    public class AddDistrictUseCase
    {
        private readonly IDistrictRepository repository;

        public AddDistrictUseCase(IDistrictRepository repository)
        {
            this.repository = repository;
        }

        public async Task ExecuteAsync(District district)
        {
            if (string.IsNullOrWhiteSpace(district.Name))
                throw new ArgumentException("District name is required");

            await repository.AddAsync(district);
        }
    }
}
