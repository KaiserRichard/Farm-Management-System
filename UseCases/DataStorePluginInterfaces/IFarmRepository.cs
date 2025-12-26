using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IFarmRepository
    {
        IEnumerable<Farm> GetFarms();
        void AddFarm(Farm farm);
        // PHẢI CÓ DẤU ? Ở ĐÂY để khớp với Repository bạn vừa gửi
        Farm? GetFarmById(int farmId); 
        void UpdateFarm(Farm farm);
        void DeleteFarm(int farmId);
    }
}