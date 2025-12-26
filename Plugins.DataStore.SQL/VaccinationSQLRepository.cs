using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Plugins.DataStore.SQL
{
    public class VaccinationSQLRepository : IVaccinationRepository
    {
        private readonly FarmContext _db;
        public VaccinationSQLRepository(FarmContext db) => _db = db;

        public IEnumerable<Vaccination> GetVaccinations()
            => _db.Vaccinations
                .Include(v => v.Animal)
                .Include(v => v.Supply)
                .ToList();

        public void AddVaccination(Vaccination vaccination)
        {
            _db.Vaccinations.Add(vaccination);
            _db.SaveChanges();
        }

        public Vaccination? GetVaccinationById(int id) => _db.Vaccinations.Find(id);

        public void UpdateVaccination(Vaccination vaccination)
        {
            var existing = _db.Vaccinations.Find(vaccination.VaccinationId);
            if (existing != null)
            {
                existing.AdministeredDate = vaccination.AdministeredDate;
                existing.IsCompleted = vaccination.IsCompleted;
                existing.Note = vaccination.Note;
                _db.SaveChanges();
            }
        }
    }
}