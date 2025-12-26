using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using UseCases.FarmsUseCases; // Thêm namespace này

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDashboardUseCase _dashboardUseCase; // Khai báo Use Case

    public HomeController(ILogger<HomeController> logger, IDashboardUseCase dashboardUseCase)
    {
        _logger = logger;
        _dashboardUseCase = dashboardUseCase;
    }

    public IActionResult Index()
    {
        // Lấy dữ liệu thống kê từ Use Case
        var stats = _dashboardUseCase.Execute();

        // Truyền dữ liệu ra View thông qua ViewBag
        ViewBag.TotalAnimals = stats.TotalAnimals;
        ViewBag.PendingVaccinations = stats.PendingVaccines;
        ViewBag.LowStockSupplies = stats.LowStock;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}