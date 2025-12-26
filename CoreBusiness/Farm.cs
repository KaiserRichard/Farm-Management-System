using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Farm
    {
        public int FarmId { get; set; }

        [Required(ErrorMessage = "Tên trại không được để trống")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Address { get; set; } = string.Empty;

        public string? OwnerName { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; } = string.Empty;

        // Một trại có nhiều vật nuôi
        public List<Animal>? Animals { get; set; }
    }
}