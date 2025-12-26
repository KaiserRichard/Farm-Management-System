using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ISupplyRepository
    {
        IEnumerable<Supply> GetSupplies();
        void AddSupply(Supply supply);
        Supply? GetSupplyById(int supplyId);
        void UpdateSupply(Supply supply);
    }
}