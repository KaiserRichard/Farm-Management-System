using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ICommuneRepository
    {
        Task<IEnumerable<Commune>> GetAllAsync();
        Task AddAsync(Commune commune);
    }
}
