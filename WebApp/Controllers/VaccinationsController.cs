using Microsoft.AspNetCore.Mvc;
using UseCases.FarmsUseCases;
using CoreBusiness;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace WebApp.Controllers
{
    public class VaccinationsController : Controller
    {
        private readonly IViewVaccinationsUseCase _view;
        private readonly ICompleteVaccinationUseCase _complete;
        private readonly IAddVaccinationUseCase _add;
        private readonly UseCases.DataStorePluginInterfaces.IAnimalRepository _animalRepo;
        private readonly UseCases.DataStorePluginInterfaces.ISupplyRepository _supplyRepo;

        public VaccinationsController(IViewVaccinationsUseCase view,
                                     ICompleteVaccinationUseCase complete,
                                     IAddVaccinationUseCase add,
                                     UseCases.DataStorePluginInterfaces.IAnimalRepository animalRepo,
                                     UseCases.DataStorePluginInterfaces.ISupplyRepository supplyRepo)
        {
            _view = view; _complete = complete; _add = add;
            _animalRepo = animalRepo; _supplyRepo = supplyRepo;
        }

        public IActionResult Index() => View(_view.Execute());

        public IActionResult Create()
        {
            ViewBag.Animals = new SelectList(_animalRepo.GetAnimals(), "AnimalId", "Name");

            // Lọc danh sách chỉ lấy Vaccine/Thuốc có Category là "Y tế"
            var medicalSupplies = _supplyRepo.GetSupplies()
                                             .Where(s => s.Category == "Y tế")
                                             .ToList();

            ViewBag.Supplies = new SelectList(medicalSupplies, "SupplyId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Vaccination v)
        {
            if (ModelState.IsValid)
            {
                _add.Execute(v);
                return RedirectToAction(nameof(Index));
            }
            return View(v);
        }

        public IActionResult Confirm(int id)
        {
            _complete.Execute(id);
            return RedirectToAction(nameof(Index));
        }
    }
}