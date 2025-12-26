using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace Plugins.DataStore.SQL
{
    public class SupplySQLRepository : ISupplyRepository
    {
        private readonly FarmContext _db;
        public SupplySQLRepository(FarmContext db) => _db = db;

        public IEnumerable<Supply> GetSupplies() => _db.Supplies.ToList();

        public void AddSupply(Supply supply)
        {
            _db.Supplies.Add(supply);
            _db.SaveChanges();
        }

        public Supply? GetSupplyById(int supplyId) => _db.Supplies.Find(supplyId);

        public void UpdateSupply(Supply supply)
        {
            var existing = _db.Supplies.Find(supply.SupplyId);
            if (existing != null)
            {
                existing.Name = supply.Name;
                existing.Unit = supply.Unit;
                existing.Quantity = supply.Quantity;
                existing.Price = supply.Price;
                _db.SaveChanges();
            }
        }
    }
}