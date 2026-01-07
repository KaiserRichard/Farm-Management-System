using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.SQL;
using Microsoft.AspNetCore.Identity;
using WebApp.Areas.Identity.Data;

// === Administrative (District) module ===
// UseCases contain business logic
using UseCases.Administrative;

// Interfaces used by UseCases to access data store
using UseCases.DataStorePluginInterfaces;

// SQL implementation of repositories (Infrastructure layer)
using Plugins.DataStore.SQL.Administrative;

// Aliases to keep Program.cs readable
using UCInterfaces = UseCases.DataStorePluginInterfaces;
using UCFarms = UseCases.FarmsUseCases;

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------------
// 1. DATABASE CONFIGURATION
// --------------------------------------------------
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Identity database (authentication & authorization)
builder.Services.AddDbContext<FarmIdentityContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Main application database (Farm, Animal, Supply, District, etc.)
builder.Services.AddDbContext<FarmContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// --------------------------------------------------
// 2. IDENTITY & AUTHORIZATION
// --------------------------------------------------
builder.Services
    .AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<FarmIdentityContext>()
    .AddDefaultUI()              
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", p => p.RequireClaim("Position", "Admin"));
    options.AddPolicy("StaffPolicy", p => p.RequireClaim("Position", "Staff"));
});

// --------------------------------------------------
// 3. UI CONFIGURATION
// --------------------------------------------------
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

// --------------------------------------------------
// 4. DEPENDENCY INJECTION REGISTRATION
// --------------------------------------------------

// === Repositories (Data access layer) ===
builder.Services.AddTransient<UCInterfaces.IFarmRepository, FarmSQLRepository>();
builder.Services.AddTransient<UCInterfaces.IAnimalRepository, AnimalSQLRepository>();
builder.Services.AddTransient<UCInterfaces.ISupplyRepository, SupplySQLRepository>();
builder.Services.AddTransient<UCInterfaces.ISupplyTransactionRepository, SupplyTransactionSQLRepository>();
builder.Services.AddTransient<UCInterfaces.IVaccinationRepository, VaccinationSQLRepository>();

// === UseCases for Farm management ===
builder.Services.AddTransient<UCFarms.IViewFarmsUseCase, UCFarms.ViewFarmsUseCase>();
builder.Services.AddTransient<UCFarms.IAddFarmUseCase, UCFarms.AddFarmUseCase>();
builder.Services.AddTransient<UCFarms.IGetFarmByIdUseCase, UCFarms.GetFarmByIdUseCase>();
builder.Services.AddTransient<UCFarms.IEditFarmUseCase, UCFarms.EditFarmUseCase>();
builder.Services.AddTransient<UCFarms.IDeleteFarmUseCase, UCFarms.DeleteFarmUseCase>();

// === UseCases for Animal management ===
builder.Services.AddTransient<UCFarms.IViewAnimalsUseCase, UCFarms.ViewAnimalsUseCase>();
builder.Services.AddTransient<UCFarms.IAddAnimalUseCase, UCFarms.AddAnimalUseCase>();

// === UseCases for Supply & Inventory ===
builder.Services.AddTransient<UCFarms.IViewSuppliesUseCase, UCFarms.ViewSuppliesUseCase>();
builder.Services.AddTransient<UCFarms.IRecordTransactionUseCase, UCFarms.RecordTransactionUseCase>();

// === UseCases for Vaccination ===
// IMPORTANT: vaccination logic automatically updates supply quantity
builder.Services.AddTransient<UCFarms.IViewVaccinationsUseCase, UCFarms.ViewVaccinationsUseCase>();
builder.Services.AddTransient<UCFarms.ICompleteVaccinationUseCase, UCFarms.CompleteVaccinationUseCase>();
builder.Services.AddTransient<UCFarms.IAddVaccinationUseCase, UCFarms.AddVaccinationUseCase>();

// --------------------------------------------------
// Administrative module: District
// This module represents government-level administrative data
// --------------------------------------------------
builder.Services.AddScoped<IDistrictRepository, DistrictSQLRepository>(); // Data access
builder.Services.AddScoped<ViewDistrictsUseCase>();                      // Read-only business logic
builder.Services.AddScoped<AddDistrictUseCase>();                        // Create business logic
builder.Services.AddScoped<ICommuneRepository, CommuneSQLRepository>();
builder.Services.AddScoped<ViewCommunesUseCase>();
builder.Services.AddScoped<AddCommuneUseCase>();


// === Dashboard ===
builder.Services.AddTransient<UCFarms.IDashboardUseCase, UCFarms.DashboardUseCase>();

// --------------------------------------------------
// 5. HTTP REQUEST PIPELINE
// --------------------------------------------------
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
