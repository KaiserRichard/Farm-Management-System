using CoreBusiness;
namespace UseCases.DataStorePluginInterfaces
{
    public interface ISupplyTransactionRepository
    {
        void AddTransaction(SupplyTransaction transaction);
    }
}