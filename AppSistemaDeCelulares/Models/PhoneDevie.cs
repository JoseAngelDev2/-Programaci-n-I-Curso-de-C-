namespace AppSistemaDeCelulares.Models
{
    public class PhoneDevice
    {
        public int PhoneDeviceId { get; set; }

        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string IMEI { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public DateTime CheckInDate { get; set; } = DateTime.Now;
        
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        
        public List<Diagnostic> Diagnostics { get; set; } = new();
        public List<Repair> Repairs { get; set; } = new();

        public Delivery? Delivery { get; set; }
    }
}