using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Supply
    {
        public int SupplyId { get; set; }

        [Required(ErrorMessage = "Tên vật tư không được để trống")]
        public string Name { get; set; } = string.Empty;

        public string? Unit { get; set; } // Đơn vị: Bao, Kg, Lít...

        [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn kho không được âm")]
        public int Quantity { get; set; } // Số lượng hiện có trong kho

        public double Price { get; set; } // Đơn giá

        // THÊM DÒNG NÀY: Để phân biệt "Thức ăn" và "Y tế"
        public string? Category { get; set; }
    }
}