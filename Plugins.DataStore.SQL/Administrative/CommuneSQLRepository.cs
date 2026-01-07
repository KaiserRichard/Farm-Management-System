using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL.Administrative
{
    public class CommuneSQLRepository : ICommuneRepository
    {
        private readonly FarmContext context;

        public CommuneSQLRepository(FarmContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Commune>> GetAllAsync()
        {
            return await context.Communes.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(Commune commune)
        {
            context.Communes.Add(commune);
            await context.SaveChangesAsync();
        }
    }
}
