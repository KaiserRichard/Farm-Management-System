using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Animal
    {
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "Tên vật nuôi không được để trống")]
        public string Name { get; set; } = string.Empty;

        public string? Species { get; set; }

        public int Age { get; set; }

        public string? HealthStatus { get; set; } = "Khỏe mạnh";

        public int FarmId { get; set; }
        public Farm? Farm { get; set; }
    }
}