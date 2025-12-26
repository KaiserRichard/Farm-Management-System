using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAnimals(); // Hàm này cực kỳ quan trọng
        IEnumerable<Animal> GetAnimalsByFarm(int farmId);
        void AddAnimal(Animal animal);
        Animal? GetAnimalById(int animalId);
        void UpdateAnimal(Animal animal);
        void DeleteAnimal(int animalId);
    }
}