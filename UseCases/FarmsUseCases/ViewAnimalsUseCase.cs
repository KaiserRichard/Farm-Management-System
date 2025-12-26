using CoreBusiness;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.FarmsUseCases
{
    public class ViewAnimalsUseCase : IViewAnimalsUseCase
    {
        private readonly IAnimalRepository _animalRepository;

        public ViewAnimalsUseCase(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public IEnumerable<Animal> Execute()
        {
            return _animalRepository.GetAnimals();
        }
    }
}