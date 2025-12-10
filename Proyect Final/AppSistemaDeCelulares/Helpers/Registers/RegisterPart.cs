using AppSistemaDeCelulares.Helpers.Forms;
using AppSistemaDeCelulares.Service;
using AppSistemaDeCelulares.Models;
using AppCustomer = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Helpers;

public class RegisterPart
{
    private static AppCustomer _context = new AppCustomer();

    public static async Task FormRegisterPart()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("=== Register New Part ===");
            
            Console.Write("Write the name of the part: ");
            string name = FormCustomers.VerifyFieldString("name");

            
            Console.Write("Write the price: ");
            string priceInput = FormCustomers.VerifyFieldString("price");

            if (!decimal.TryParse(priceInput, out decimal price))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid price.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            
            Console.Write("Write stock quantity: ");
            string stockInput = FormCustomers.VerifyFieldString("stock");

            if (!int.TryParse(stockInput, out int quantity))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid stock quantity.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            var service = new PartService(_context);

            var newPart = new Part
            {
                Name = name,
                Price = price,
                StockQuantity = quantity
            };

            await service.AddPart(newPart);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Part registered successfully!");
            Console.ResetColor();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }
}
