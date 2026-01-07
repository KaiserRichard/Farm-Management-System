using CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace Plugins.DataStore.SQL
{
    /// <summary>
    /// Main application DbContext.
    /// Contains all domain entities persisted in the database.
    /// </summary>
    public class FarmContext : DbContext
    {
        public FarmContext(DbContextOptions<FarmContext> options)
            : base(options) { }

        // -----------------------------
        // Core business entities
        // -----------------------------
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<SupplyTransaction> SupplyTransactions { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }

        // -----------------------------
        // Administrative entities
        // Government-level master data
        // -----------------------------
        public DbSet<District> Districts { get; set; }
        public DbSet<Commune> Communes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ------------------------------------------
            // Seed initial data for Supplies
            // Used for demo and development purposes
            // ------------------------------------------
            modelBuilder.Entity<Supply>().HasData(
                new Supply
                {
                    SupplyId = 1,
                    Name = "Cám heo hỗn hợp",
                    Unit = "Bao",
                    Quantity = 100,
                    Price = 320000,
                    Category = "Thức ăn"
                },
                new Supply
                {
                    SupplyId = 2,
                    Name = "Thuốc kháng sinh A",
                    Unit = "Lọ",
                    Quantity = 20,
                    Price = 150000,
                    Category = "Y tế"
                }
            );
        }
    }
}
