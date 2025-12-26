using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.SQL;
using Microsoft.AspNetCore.Identity;
using WebApp.Areas.Identity.Data;

// Sử dụng Bí danh (Alias) giúp code ngắn gọn và dễ quản lý
using UCInterfaces = UseCases.DataStorePluginInterfaces;
using UCFarms = UseCases.FarmsUseCases;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CẤU HÌNH DATABASE ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<FarmIdentityContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDbContext<FarmContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// --- 2. IDENTITY & PHÂN QUYỀN ---
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<FarmIdentityContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", p => p.RequireClaim("Position", "Admin"));
    options.AddPolicy("StaffPolicy", p => p.RequireClaim("Position", "Staff"));
});

// --- 3. CẤU HÌNH UI ---
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

// --- 4. ĐĂNG KÝ SERVICE (DEPENDENCY INJECTION) ---

// --- Đăng ký Repositories ---
builder.Services.AddTransient<UCInterfaces.IFarmRepository, FarmSQLRepository>();
builder.Services.AddTransient<UCInterfaces.IAnimalRepository, AnimalSQLRepository>();
builder.Services.AddTransient<UCInterfaces.ISupplyRepository, SupplySQLRepository>();
builder.Services.AddTransient<UCInterfaces.ISupplyTransactionRepository, SupplyTransactionSQLRepository>();
builder.Services.AddTransient<UCInterfaces.IVaccinationRepository, VaccinationSQLRepository>();

// --- Đăng ký Use Cases cho Farms (Trang trại) ---
builder.Services.AddTransient<UCFarms.IViewFarmsUseCase, UCFarms.ViewFarmsUseCase>();
builder.Services.AddTransient<UCFarms.IAddFarmUseCase, UCFarms.AddFarmUseCase>();
builder.Services.AddTransient<UCFarms.IGetFarmByIdUseCase, UCFarms.GetFarmByIdUseCase>();
builder.Services.AddTransient<UCFarms.IEditFarmUseCase, UCFarms.EditFarmUseCase>();
builder.Services.AddTransient<UCFarms.IDeleteFarmUseCase, UCFarms.DeleteFarmUseCase>();

// --- Đăng ký Use Cases cho Animals (Vật nuôi) ---
builder.Services.AddTransient<UCFarms.IViewAnimalsUseCase, UCFarms.ViewAnimalsUseCase>();
builder.Services.AddTransient<UCFarms.IAddAnimalUseCase, UCFarms.AddAnimalUseCase>();

// --- Đăng ký Use Cases cho Supplies (Vật tư & Kho) ---
builder.Services.AddTransient<UCFarms.IViewSuppliesUseCase, UCFarms.ViewSuppliesUseCase>();
builder.Services.AddTransient<UCFarms.IRecordTransactionUseCase, UCFarms.RecordTransactionUseCase>();

// --- Đăng ký Use Cases cho Tiêm chủng ---
builder.Services.AddTransient<UCFarms.IViewVaccinationsUseCase, UCFarms.ViewVaccinationsUseCase>();
builder.Services.AddTransient<UCFarms.ICompleteVaccinationUseCase, UCFarms.CompleteVaccinationUseCase>();
builder.Services.AddTransient<UCFarms.IAddVaccinationUseCase, UCFarms.AddVaccinationUseCase>();

// --- Đăng ký Use Case Dashboard ---
builder.Services.AddTransient<UCFarms.IDashboardUseCase, UCFarms.DashboardUseCase>();

// --- 5. PIPELINE XỬ LÝ REQUEST ---
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();