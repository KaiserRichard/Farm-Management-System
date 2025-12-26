using CoreBusiness;
using Microsoft.AspNetCore.Mvc;
using UseCases.FarmsUseCases;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    public class FarmsController : Controller
    {
        private readonly IViewFarmsUseCase _viewFarmsUseCase;
        private readonly IAddFarmUseCase _addFarmUseCase;
        private readonly IGetFarmByIdUseCase _getFarmByIdUseCase;
        private readonly IEditFarmUseCase _editFarmUseCase;
        private readonly IDeleteFarmUseCase _deleteFarmUseCase;

        public FarmsController(
            IViewFarmsUseCase viewFarmsUseCase,
            IAddFarmUseCase addFarmUseCase,
            IGetFarmByIdUseCase getFarmByIdUseCase,
            IEditFarmUseCase editFarmUseCase,
            IDeleteFarmUseCase deleteFarmUseCase)
        {
            _viewFarmsUseCase = viewFarmsUseCase;
            _addFarmUseCase = addFarmUseCase;
            _getFarmByIdUseCase = getFarmByIdUseCase;
            _editFarmUseCase = editFarmUseCase;
            _deleteFarmUseCase = deleteFarmUseCase;
        }

        // 1. Hiển thị danh sách trang trại
        public IActionResult Index()
        {
            var farms = _viewFarmsUseCase.Execute();
            return View(farms);
        }

        // 2. Trang Thêm mới (Giao diện)
        public IActionResult Create()
        {
            return View();
        }

        // 3. Xử lý lưu Thêm mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Farm farm)
        {
            if (ModelState.IsValid)
            {
                _addFarmUseCase.Execute(farm);
                return RedirectToAction(nameof(Index));
            }
            return View(farm);
        }

        // 4. Trang Sửa (Giao diện) - Kiểm tra kỹ dòng return View(farm)
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();

            var farm = _getFarmByIdUseCase.Execute(id.Value);

            if (farm == null) return NotFound();

            return View(farm); // QUAN TRỌNG: Phải có dòng này để hiện trang sửa
        }

        // 5. Xử lý lưu Chỉnh sửa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Farm farm)
        {
            if (ModelState.IsValid)
            {
                _editFarmUseCase.Execute(farm);
                return RedirectToAction(nameof(Index));
            }
            return View(farm);
        }

        // 6. Trang Xóa (Giao diện xác nhận) - Đây là chỗ bạn bị lỗi CS0161
        public IActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();

            var farm = _getFarmByIdUseCase.Execute(id.Value);

            if (farm == null) return NotFound();

            return View(farm); // Lệnh return này sẽ sửa lỗi CS0161
        }

        // 7. Xử lý thực hiện Xóa
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int farmId)
        {
            _deleteFarmUseCase.Execute(farmId);
            return RedirectToAction(nameof(Index));
        }
    }
}