using Microsoft.AspNetCore.Mvc;
using CoreBusiness;
using UseCases.FarmsUseCases;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers
{
    public class SuppliesController : Controller
    {
        private readonly IViewSuppliesUseCase _viewSuppliesUseCase;
        private readonly IRecordTransactionUseCase _recordTransactionUseCase;
        private readonly UseCases.DataStorePluginInterfaces.ISupplyRepository _supplyRepository;

        public SuppliesController(IViewSuppliesUseCase viewSuppliesUseCase,
                                  IRecordTransactionUseCase recordTransactionUseCase,
                                  UseCases.DataStorePluginInterfaces.ISupplyRepository supplyRepository)
        {
            _viewSuppliesUseCase = viewSuppliesUseCase;
            _recordTransactionUseCase = recordTransactionUseCase;
            _supplyRepository = supplyRepository;
        }

        public IActionResult Index() => View(_viewSuppliesUseCase.Execute());

        public IActionResult Record()
        {
            ViewBag.Supplies = new SelectList(_supplyRepository.GetSupplies(), "SupplyId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Record(SupplyTransaction transaction)
        {
            if (ModelState.IsValid)
            {
                _recordTransactionUseCase.Execute(transaction);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Supplies = new SelectList(_supplyRepository.GetSupplies(), "SupplyId", "Name");
            return View(transaction);
        }
    }
}