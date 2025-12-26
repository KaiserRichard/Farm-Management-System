using CoreBusiness;
using System.Collections.Generic;
namespace UseCases.FarmsUseCases
{
    public interface IViewAnimalsUseCase
    {
        IEnumerable<Animal> Execute();
    }
}

