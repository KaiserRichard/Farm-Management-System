using CoreBusiness;
using System.Collections.Generic;
namespace UseCases.DataStorePluginInterfaces
{
    public interface IVaccinationRepository
    {
        IEnumerable<Vaccination> GetVaccinations();
        void AddVaccination(Vaccination vaccination);
        Vaccination? GetVaccinationById(int id);
        void UpdateVaccination(Vaccination vaccination);
    }
}