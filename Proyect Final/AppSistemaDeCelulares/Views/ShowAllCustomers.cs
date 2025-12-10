using AppSistemaDeCelulares.Service;
using AppCustomer = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Views;

public class ShowViews
{
    public static void ShowAllCustomers(AppCustomer _context)
    {
        CustomerServices customerServices = new CustomerServices(_context);
        int contador = 1;
        
        foreach (var item in customerServices.GetAllCustomers())
        {
            
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
        
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"║  ID         : {item.CustomerId}");
            Console.WriteLine($"║  Name       : {item.Name}");
            Console.WriteLine($"║  Email      : {item.Email}");
            Console.WriteLine($"║  Address    : {item.Address}");
            Console.WriteLine($"║  Registered : {item.DateRegister}");
            Console.WriteLine($"║  Phone :\n");
            foreach (var phone in item.PhoneDevices)
            { 
                Console.WriteLine($"║Model: {phone.Model}\nIMEI: {phone.IMEI}\n\n");
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╚═══════════════════════════════════════════════╝\n");
        
            Console.ResetColor();
        }
        
        Console.WriteLine("Press  any key to continue...");
        Console.ReadKey();

    }
}