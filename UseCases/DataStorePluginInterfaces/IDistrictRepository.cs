using CoreBusiness.Entities.Administrative;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IDistrictRepository
    {
        Task<IEnumerable<District>> GetAllAsync();
        Task AddAsync(District district);
    }
}
