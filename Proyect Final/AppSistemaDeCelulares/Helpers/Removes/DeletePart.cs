using AppSistemaDeCelulares.Helpers.Forms;
using AppSistemaDeCelulares.Service;
using AppSistemaDeCelulares.Views;
using AppDb = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Helpers
{
    public class DeletePart
    {
        private static AppDb _context = new AppDb();

        public static async Task FormDeletePart()
        {
            try
            {
                Console.Clear();
                ShowAllParts.ShowParts();

                Console.Write("Write the ID of the Part to delete: ");
                string inputId = FormCustomers.VerifyFieldString("id");

                if (!int.TryParse(inputId, out int id))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid ID.");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }

                var service = new PartService(_context);
                var part = await service.GetPart(id);

                if (part == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Part not found.");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }

                await service.RemovePart(part);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Part deleted successfully!");
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