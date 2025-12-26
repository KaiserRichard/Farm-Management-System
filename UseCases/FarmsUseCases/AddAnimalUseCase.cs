using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.FarmsUseCases
{
    public class AddAnimalUseCase : IAddAnimalUseCase
    {
        private readonly IAnimalRepository _animalRepository;

        public AddAnimalUseCase(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public void Execute(Animal animal)
        {
            _animalRepository.AddAnimal(animal);
        }
    }
}