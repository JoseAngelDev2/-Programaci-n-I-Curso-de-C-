using AppSistemaDeCelulares.Helpers.Forms;
using AppSistemaDeCelulares.Models;
using AppSistemaDeCelulares.Service;
using AppSistemaDeCelulares.Views;
using AppDevice = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Helpers;

public class EditDevice
{
    private static AppDevice _context = new AppDevice();

    public static async Task FormEditDevice()
    {
        try
        {
            ShowAllPhones.ShowPhones();

            Console.Write("Write the id of Device: ");
            string inputId = FormCustomers.VerifyFieldString("id");

            if (!int.TryParse(inputId, out int id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ID.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            
            var service = new PhoneDeviceServices(_context);
            var device = await service.GetPhoneDevice(id);

            if (device == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Device not found.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Editing Device...");

            Console.Write("New Brand: ");
            string newBrand = FormCustomers.VerifyFieldString("brand");

            Console.Write("New Model: ");
            string newModel = FormCustomers.VerifyFieldString("model");
            
            string newImei = GetImei.GetRandomImei()!;
            

            Console.Write("New Customer Id: ");
            string inputCustomer = FormCustomers.VerifyFieldString("customer id");

            if (!int.TryParse(inputCustomer, out int newCustomerId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Customer ID.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }
            
            device.Brand = newBrand;
            device.Model = newModel;
            device.IMEI = newImei;
            device.CustomerId = newCustomerId;

            await service.UpdatePhoneDevide(device);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Device updated successfully!");
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
