using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class FarmSQLRepository : IFarmRepository
    {
        private readonly FarmContext _db;

        public FarmSQLRepository(FarmContext db)
        {
            _db = db;
        }

        public IEnumerable<Farm> GetFarms()
        {
            return _db.Farms.AsNoTracking().ToList();
        }

        public void AddFarm(Farm farm)
        {
            _db.Farms.Add(farm);
            _db.SaveChanges();
        }

        public Farm? GetFarmById(int farmId)
        {
            // Sử dụng Find để đảm bảo lấy trực tiếp từ DB/Context ổn định cho trang Edit
            return _db.Farms.Find(farmId);
        }

        public void UpdateFarm(Farm farm)
        {
            var farmToUpdate = _db.Farms.Find(farm.FarmId);
            if (farmToUpdate != null)
            {
                farmToUpdate.Name = farm.Name;
                farmToUpdate.Address = farm.Address;
                farmToUpdate.OwnerName = farm.OwnerName;
                farmToUpdate.PhoneNumber = farm.PhoneNumber;
                _db.SaveChanges();
            }
        }

        public void DeleteFarm(int farmId)
        {
            var farmToDelete = _db.Farms.Find(farmId);
            if (farmToDelete != null)
            {
                _db.Farms.Remove(farmToDelete);
                _db.SaveChanges();
            }
        }
    }
}