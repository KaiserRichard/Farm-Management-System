using CoreBusiness;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.FarmsUseCases
{
    public interface IViewFarmsUseCase { IEnumerable<Farm> Execute(); }
    public class ViewFarmsUseCase : IViewFarmsUseCase
    {
        private readonly IFarmRepository _repo;
        public ViewFarmsUseCase(IFarmRepository repo) => _repo = repo;
        public IEnumerable<Farm> Execute() => _repo.GetFarms();
    }
}