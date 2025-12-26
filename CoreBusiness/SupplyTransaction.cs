using System;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public enum TransactionType { Import = 1, Export = 2 }

    public class SupplyTransaction
    {
        public int SupplyTransactionId { get; set; }

        [Required]
        public int SupplyId { get; set; }
        public Supply? Supply { get; set; }

        public TransactionType ActionType { get; set; } // 1: Nhập, 2: Xuất

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int Quantity { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;
    }
}