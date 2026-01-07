using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Administrative;
using UseCases.DataStorePluginInterfaces;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CommunesController : Controller
    {
        private readonly ViewCommunesUseCase viewUseCase;
        private readonly AddCommuneUseCase addUseCase;
        private readonly IDistrictRepository districtRepository;

        public CommunesController(
            ViewCommunesUseCase viewUseCase,
            AddCommuneUseCase addUseCase,
            IDistrictRepository districtRepository)
        {
            this.viewUseCase = viewUseCase;
            this.addUseCase = addUseCase;
            this.districtRepository = districtRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Districts = await districtRepository.GetAllAsync();
            var communes = await viewUseCase.ExecuteAsync();
            return View(communes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Commune commune)
        {
            await addUseCase.ExecuteAsync(commune);
            return RedirectToAction(nameof(Index));
        }
    }
}
