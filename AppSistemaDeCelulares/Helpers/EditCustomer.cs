using AppSistemaDeCelulares.Helpers.Forms;
using AppSistemaDeCelulares.Models;
using AppSistemaDeCelulares.Service;
using AppSistemaDeCelulares.Views;
using AppCustomer = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Helpers;

public class FormEditCustomer
{
    private static AppCustomer _context = new AppCustomer();

    public static async Task EditCustomer()
    {
        try
        {
            ShowViews.ShowAllCustomers(_context);

            Console.Write("Write the id of Customer: ");
            string inputId = FormCustomers.VerifyFieldString("id");

            if (!int.TryParse(inputId, out int id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ID.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            var service = new CustomerServices(_context);
            var customer = await service.GetCustomer(id);

            if (customer == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Customer not found.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Editing Customer...");
            Console.Write("New Name: ");
            string newName = FormCustomers.VerifyFieldString("name");

            Console.Write("New Email: ");
            string newEmail = FormCustomers.VerifyFieldString("email");

            Console.Write("New Phone: ");
            string newPhone = FormCustomers.VerifyFieldString("phone");

            Console.Write("New Address: ");
            string newAddress = FormCustomers.VerifyFieldString("address");

            customer.Name = newName;
            customer.Email = newEmail;
            customer.Phone = newPhone;
            customer.Address = newAddress;

            await service.UpdateCustomer(customer);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Customer updated successfully!");
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
