using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UseCases.FarmsUseCases; // Quan trọng: Phải có dòng này
using CoreBusiness;

namespace WebApp.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly IViewAnimalsUseCase _viewAnimalsUseCase;
        private readonly IAddAnimalUseCase _addAnimalUseCase;
        private readonly IViewFarmsUseCase _viewFarmsUseCase;

        // Tiêm các Use Case vào Controller
        public AnimalsController(
            IViewAnimalsUseCase viewAnimalsUseCase,
            IAddAnimalUseCase addAnimalUseCase,
            IViewFarmsUseCase viewFarmsUseCase)
        {
            _viewAnimalsUseCase = viewAnimalsUseCase;
            _addAnimalUseCase = addAnimalUseCase;
            _viewFarmsUseCase = viewFarmsUseCase;
        }

        // Hiện danh sách vật nuôi
        public IActionResult Index()
        {
            var animals = _viewAnimalsUseCase.Execute();
            return View(animals);
        }

        // Hiện form thêm mới (Sửa lỗi 404)
        public IActionResult Create()
        {
            var farms = _viewFarmsUseCase.Execute();
            ViewBag.Farms = new SelectList(farms, "FarmId", "Name");
            return View();
        }

        // Xử lý lưu dữ liệu
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _addAnimalUseCase.Execute(animal);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Farms = new SelectList(_viewFarmsUseCase.Execute(), "FarmId", "Name");
            return View(animal);
        }
    }
}