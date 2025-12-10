using AppSistemaDeCelulares.Service;
using AppSistemaDeCelulares.Views;
using AppGetImei = AppSistemaDeCelulares.Helpers.GetImei;
using AppCustomer = AppSistemaDeCelulares.Data.ApplicationDbContext;
namespace AppSistemaDeCelulares.Helpers.Forms;

public class FormPhoneDevices
{
    private static readonly List<string> statusPhone = ["Good", "Bad"];
    private static AppCustomer _context = new AppCustomer();
    public static async Task FormPhoneDevice()
    {
        try
        {
            CustomerServices customerServices = new CustomerServices(_context);
            string imei = string.Empty;
            int id = 0;
        
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to FormPhoneDevices");
            ShowViews.ShowAllCustomers(_context);
        
            Console.WriteLine("Write the id of Customer: ");
            
            while (id == 0)
            {
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid ID. Returning to menu...");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }
            }
            
            var customerFound = await customerServices.GetCustomer(id);
        
            if (customerFound == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Customer not found");
                Console.ReadKey();
                Console.ResetColor();
                return;
            }
        
            Console.Clear();
            Console.Write("Write the brand of Phone: ");
            string brand = FormCustomers.VerifyFieldString("brand");
            Console.Write("Write the model of Phone: ");
            string model = FormCustomers.VerifyFieldString("model");
            Console.ResetColor();
        
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            imei = GetImei.GetRandomImei()!;
            Console.ResetColor();
        
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Write the Color of Phone: ");
            string colorPhone = FormCustomers.VerifyFieldString("colorPhone");
            Console.WriteLine("Select the status phone: ");
            Console.WriteLine("1. Good");
            Console.WriteLine("2. Bad");
        
            int index = Console.ReadLine() == "1" ? 0 : 1;
        
            string status =  statusPhone[index];
        
            await RegisterPhoneDevices.RegisterPhoneDevice(brand, model, status, imei, colorPhone, id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}