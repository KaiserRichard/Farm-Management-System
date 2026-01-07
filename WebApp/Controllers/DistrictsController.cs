using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Administrative;
using CoreBusiness.Entities.Administrative;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DistrictsController : Controller
    {
        private readonly ViewDistrictsUseCase viewUseCase;
        private readonly AddDistrictUseCase addUseCase;

        public DistrictsController(
            ViewDistrictsUseCase viewUseCase,
            AddDistrictUseCase addUseCase)
        {
            this.viewUseCase = viewUseCase;
            this.addUseCase = addUseCase;
        }

        public async Task<IActionResult> Index()
        {
            var districts = await viewUseCase.ExecuteAsync();
            return View(districts);
        }

        [HttpPost]
        public async Task<IActionResult> Create(District district)
        {
            await addUseCase.ExecuteAsync(district);
            return RedirectToAction(nameof(Index));
        }
    }
}
