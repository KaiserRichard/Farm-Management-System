namespace CoreBusiness
{
    public class Commune
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        // Foreign Key to District
        public int DistrictId { get; set; }
    }
}
