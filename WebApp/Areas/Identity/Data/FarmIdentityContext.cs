using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Areas.Identity.Data
{
    // Kế thừa từ IdentityDbContext, sử dụng lớp IdentityUser mặc định
    public class FarmIdentityContext : IdentityDbContext<IdentityUser>
    {
        public FarmIdentityContext(DbContextOptions<FarmIdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Chúng ta không cần thêm logic tùy chỉnh nào ở đây.
        }
    }
}