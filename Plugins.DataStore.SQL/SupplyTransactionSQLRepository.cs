using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class SupplyTransactionSQLRepository : ISupplyTransactionRepository
    {
        private readonly FarmContext _db;
        public SupplyTransactionSQLRepository(FarmContext db) => _db = db;
        public void AddTransaction(SupplyTransaction transaction)
        {
            _db.SupplyTransactions.Add(transaction);
            _db.SaveChanges();
        }
    }
}