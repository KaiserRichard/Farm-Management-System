using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL.Administrative
{
    public class DistrictSQLRepository : IDistrictRepository
    {
        private readonly FarmContext context;

        public DistrictSQLRepository(FarmContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<District>> GetAllAsync()
        {
            return await context.Districts.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(District district)
        {
            context.Districts.Add(district);
            await context.SaveChangesAsync();
        }
    }
}
