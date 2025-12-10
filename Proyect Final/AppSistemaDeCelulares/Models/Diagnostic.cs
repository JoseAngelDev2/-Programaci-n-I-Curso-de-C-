namespace AppSistemaDeCelulares.Models
{
    public class Diagnostic
    {
        public int DiagnosisId { get; set; }

        public int PhoneDeviceId { get; set; }
        public PhoneDevice PhoneDevice { get; set; }

        public int TechnicianId { get; set; }
        public Technician Technician { get; set; }

        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;

        public decimal EstimatedCost { get; set; }

        public List<RepairDetail> ListRepairDetails { get; set; } = new();
    }
}