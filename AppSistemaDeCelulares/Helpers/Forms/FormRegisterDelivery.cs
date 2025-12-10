using AppSistemaDeCelulares.Helpers.Forms;
using AppSistemaDeCelulares.Models;
using AppSistemaDeCelulares.Service;
using AppSistemaDeCelulares.Views;
using AppDeliveries = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Helpers.Forms;

public class FormRegisterDeliverys
{
    public static async Task FormRegisterDelivery()
    {
        var activeDB = CheckedConnectionDB.CheckConnectionDb();
        if (!activeDB) return;

        Console.Clear();
        ShowAllPhones.ShowPhones();

        Console.Write("Write the PhoneDevice ID: ");
        string inputId = FormCustomers.VerifyFieldString("id");

        if (!int.TryParse(inputId, out int phoneId))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid ID.");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        using var context = new AppDeliveries();
        var phoneService = new PhoneDeviceServices(context);
        var foundPhone = await phoneService.GetPhoneDevice(phoneId);

        if (foundPhone == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Phone Device not found.");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        Console.Write("Total Amount: ");
        string amountInput = FormCustomers.VerifyFieldString("amount");

        if (!decimal.TryParse(amountInput, out decimal amount))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid amount.");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        Console.Write("Notes: ");
        string notes = FormCustomers.VerifyFieldString("notes");

        var newDelivery = new Delivery
        {
            PhoneDeviceId = phoneId,
            TotalAmount = amount,
            Notes = notes
        };

        var deliveryService = new DeliveryService(context);

        try
        {
            await deliveryService.AddDelivery(newDelivery);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Delivery registered successfully!");
            Console.ResetColor();
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error saving delivery: " + e.Message);
            if (e.InnerException != null)
                Console.WriteLine("Inner Exception: " + e.InnerException.Message);
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
