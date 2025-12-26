using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Plugins.DataStore.SQL
{
    public class AnimalSQLRepository : IAnimalRepository
    {
        private readonly FarmContext _db;
        public AnimalSQLRepository(FarmContext db) => _db = db;

        public IEnumerable<Animal> GetAnimals()
        {
            // Sử dụng Include để lấy luôn thông tin Trang trại kèm theo
            return _db.Animals.Include(a => a.Farm).ToList();
        }

        public IEnumerable<Animal> GetAnimalsByFarm(int farmId)
        {
            return _db.Animals.Where(a => a.FarmId == farmId).ToList();
        }

        public void AddAnimal(Animal animal)
        {
            _db.Animals.Add(animal);
            _db.SaveChanges();
        }

        public Animal? GetAnimalById(int animalId) => _db.Animals.Find(animalId);

        public void UpdateAnimal(Animal animal)
        {
            var existing = _db.Animals.Find(animal.AnimalId);
            if (existing != null)
            {
                existing.Name = animal.Name;
                existing.Species = animal.Species;
                existing.Age = animal.Age;
                existing.FarmId = animal.FarmId;
                _db.SaveChanges();
            }
        }

        public void DeleteAnimal(int animalId)
        {
            var animal = _db.Animals.Find(animalId);
            if (animal != null)
            {
                _db.Animals.Remove(animal);
                _db.SaveChanges();
            }
        }
    }
}