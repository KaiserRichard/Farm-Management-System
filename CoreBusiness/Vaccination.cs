using System;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Vaccination
    {
        public int VaccinationId { get; set; }
        public int AnimalId { get; set; }
        public Animal? Animal { get; set; }
        public int SupplyId { get; set; }
        public Supply? Supply { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }
        public DateTime? AdministeredDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public string? Note { get; set; }
    }
}