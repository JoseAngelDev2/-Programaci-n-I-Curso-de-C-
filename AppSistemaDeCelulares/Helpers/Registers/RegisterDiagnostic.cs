using AppSistemaDeCelulares.Helpers.Forms;
using AppSistemaDeCelulares.Service;
using AppSistemaDeCelulares.Views;
using AppSistemaDeCelulares.Models;
using AppCustomer = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Helpers;

public class RegisterDiagnostic
{
    private static AppCustomer _context = new AppCustomer();

    public static async Task FormRegisterDiagnostic()
    {
        try
        {
            Console.Clear();
            ShowAllPhones.ShowPhones();

            Console.Write("Write the id of the Phone Device: ");
            string inputId = FormCustomers.VerifyFieldString("Phone Device ID");

            if (!int.TryParse(inputId, out int phoneId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ID.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            
            var phoneService = new PhoneDeviceServices(_context);
            var foundPhone = await phoneService.GetPhoneDevice(phoneId);

            if (foundPhone == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Phone device not found");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            
            Console.Write("Write the description of the problem: ");
            string description = FormCustomers.VerifyFieldString("description");

            Console.Write("Write diagnostic price: ");
            string priceInput = FormCustomers.VerifyFieldString("price");

            if (!decimal.TryParse(priceInput, out decimal price))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid price");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            var service = new DiagnosticServices(_context);

            var newDiagnostic = new Diagnostic
            {
                Description = description,
                EstimatedCost = price,
                PhoneDeviceId = phoneId,
                TechnicianId = 1
            };

            await service.AddDiagnostic(newDiagnostic);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Diagnostic registered successfully!");
            Console.ResetColor();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
