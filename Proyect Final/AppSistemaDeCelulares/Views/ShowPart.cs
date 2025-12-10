using AppSistemaDeCelulares.Service;
using AppSistemaDeCelulares.Models;
using AppDb = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Views
{
    public static class ShowAllParts
    {
        private static AppDb _context = new AppDb();

        public static void ShowParts()
        {
            Console.Clear();
            Console.WriteLine("=== PARTS LIST ===");

            var service = new PartService(_context);
            var parts = service.GetAllParts().Result;

            if (parts.Count == 0)
            {
                Console.WriteLine("No parts registered.");
                return;
            }

            foreach (var p in parts)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"ID: {p.PartId}");
                Console.WriteLine($"Name: {p.Name}");
                Console.WriteLine($"Price: {p.Price:C}");
                Console.WriteLine($"Stock: {p.StockQuantity}");
            }
            Console.WriteLine("----------------------------------\n");
        }
    }
}