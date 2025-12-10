namespace AppSistemaDeCelulares.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? Address { get; set; }

        public DateTime DateRegister { get; set; } = DateTime.Now;

        public List<PhoneDevice> PhoneDevices { get; set; } = new();

    }
}


