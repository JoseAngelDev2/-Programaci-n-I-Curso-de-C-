namespace AppSistemaDeCelulares.Models
{
    public class Repair
    {
        public int RepairId { get; set; }

        public int PhoneDeviceId { get; set; }
        public PhoneDevice PhoneDevice { get; set; }

        public int TechnicianId { get; set; }
        public Technician Technician { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime? EndDate { get; set; }

        public decimal LaborCost { get; set; }

        public string Status { get; set; } = string.Empty;

        public List<RepairDetail> ListRepairDetails { get; set; } = new();
    }
}