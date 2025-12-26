using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApp.Controllers
{
    public class AccountManagerController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AccountManagerController(UserManager<IdentityUser> userManager) => _userManager = userManager;

        public IActionResult Index() => View(_userManager.Users.ToList());

        [HttpPost]
        public async Task<IActionResult> Promote(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // Thêm quyền Admin vào Database
                await _userManager.AddClaimAsync(user, new Claim("Position", "Admin"));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}