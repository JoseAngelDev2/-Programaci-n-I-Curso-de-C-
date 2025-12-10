using AppSistemaDeCelulares.Helpers.Forms;
using AppSistemaDeCelulares.Models;
using AppSistemaDeCelulares.Service;
using AppDeliveries = AppSistemaDeCelulares.Data.ApplicationDbContext;
using AppSistemaDeCelulares.Views;
using AppCustomer = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Helpers.Registers
{
    public class RegisterDeliverys
    {
        public static async Task RegisterDelivery(decimal amount, string notes)
        {
            try
            {
                AppDeliveries context = new AppDeliveries();
                DeliveryService service = new DeliveryService(context);

                var newDelivery = new Delivery
                {
                    TotalAmount = amount,
                    Notes = notes
                };

                await service.AddDelivery(newDelivery);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Delivery registered successfully!");
                Console.ResetColor();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
