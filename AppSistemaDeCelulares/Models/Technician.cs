

namespace AppSistemaDeCelulares.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Specialty { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public List<Diagnostic> Diagnoses { get; set; } = new();
        public List<Repair> Repairs { get; set; } = new();
    }
}