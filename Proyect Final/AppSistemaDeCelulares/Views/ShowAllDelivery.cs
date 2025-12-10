using AppSistemaDeCelulares.Service;
using AppDb = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Views
{
    public static class ShowAllDeliveries
    {
        private static AppDb _context = new AppDb();

        public static void ShowDeliveries()
        {
            Console.Clear();
            Console.WriteLine("=== DELIVERIES LIST ===");

            var service = new DeliveryService(_context);
            var deliveries = service.GetAllDeliveries().Result;

            if (deliveries.Count == 0)
            {
                Console.WriteLine("No deliveries registered.");
                return;
            }

            foreach (var d in deliveries)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"ID: {d.DeliveryId}");
                Console.WriteLine($"Phone: {d.PhoneDevice.Brand} {d.PhoneDevice.Model}");
                Console.WriteLine($"Delivery Date: {d.DeliveryDate}");
                Console.WriteLine($"Total Amount: {d.TotalAmount:C}");
                Console.WriteLine($"Notes: {d.Notes}");
            }

            Console.WriteLine("----------------------------------\n");
        }
    }
}