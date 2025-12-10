using AppSistemaDeCelulares.Service;
using AppPhoneDevie = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Views;

public abstract class ShowAllPhones
{
   private static AppPhoneDevie _context =  new AppPhoneDevie();

   public static void ShowPhones()
   {
      PhoneDeviceServices phoneDeviceServices = new PhoneDeviceServices(_context);
      
      foreach (var item in phoneDeviceServices.GetAllPhoneDevices())
      {
         Console.ForegroundColor = ConsoleColor.Magenta;
         Console.WriteLine("╔═══════════════════════════════════════════════╗");
        
         Console.ForegroundColor = ConsoleColor.White;
         Console.WriteLine($"║  ID         : {item.PhoneDeviceId}");
         Console.WriteLine($"║  Model       : {item.Model}");
         Console.WriteLine($"║  Imei      : {item.IMEI}");
         Console.WriteLine($"║  Brand    : {item.Brand}");
         Console.WriteLine($"║  Color : {item.Color}");
         Console.WriteLine($"║  Status : {item.Status}");
         Console.WriteLine($"║  Time : {item.CheckInDate}");
        
         Console.ForegroundColor = ConsoleColor.Magenta;
         Console.WriteLine("╚═══════════════════════════════════════════════╝\n");
        
         Console.ResetColor();
      }
      Console.WriteLine("Press  any key to continue...");
      Console.ReadKey();
   }
}