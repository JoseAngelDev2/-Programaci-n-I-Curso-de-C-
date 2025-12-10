namespace AppSistemaDeCelulares.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }

        public int PhoneDeviceId { get; set; }
        public PhoneDevice PhoneDevice { get; set; }

        public DateTime DeliveryDate { get; set; } = DateTime.Now;

        public decimal TotalAmount { get; set; }

        public string Notes { get; set; } = string.Empty;
    }
}