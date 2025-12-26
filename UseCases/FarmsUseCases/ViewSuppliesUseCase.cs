using CoreBusiness;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.FarmsUseCases
{
    public interface IViewSuppliesUseCase
    {
        IEnumerable<Supply> Execute();
    }

    public class ViewSuppliesUseCase : IViewSuppliesUseCase
    {
        private readonly ISupplyRepository _supplyRepository;
        public ViewSuppliesUseCase(ISupplyRepository supplyRepository) => _supplyRepository = supplyRepository;
        public IEnumerable<Supply> Execute() => _supplyRepository.GetSupplies();
    }
}