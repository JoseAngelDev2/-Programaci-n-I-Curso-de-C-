namespace AppSistemaDeCelulares.Models
{
    public class RepairDetail
    {
        public int RepairDetailId { get; set; }

        public int RepairId { get; set; }
        public Repair Repair { get; set; }

        public string Description { get; set; } = string.Empty;

        public int? PartId { get; set; }
        public Part? Part { get; set; }

        public decimal Cost { get; set; }
    }
}