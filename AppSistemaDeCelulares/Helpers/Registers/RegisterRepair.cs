using AppSistemaDeCelulares.Helpers.Forms;
using AppSistemaDeCelulares.Models;
using AppSistemaDeCelulares.Service;
using AppSistemaDeCelulares.Views;
using AppDb = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Helpers;

public class RegisterRepairDetail
{
    private static AppDb _context = new AppDb();

    public static async Task FormRegisterRepairDetail()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("=== REGISTER REPAIR DETAIL ===");
            
            // ---- Mostrar Repairs ----
            ShowAllParts.ShowParts();

            Console.Write("Write the Repair ID: ");
            string repairIdInput = FormCustomers.VerifyFieldString("Repair ID");

            if (!int.TryParse(repairIdInput, out int repairId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Repair ID");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            var repairService = new AppRepairService(_context);
            var foundRepair = await repairService.GetRepair(repairId);

            if (foundRepair == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Repair not found");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            // ---- Mostrar Parts ----
            ShowAllParts.ShowParts();

            Console.Write("Write the Part ID (optional, press Enter to skip): ");
            string partIdInput = Console.ReadLine()!;

            int? partId = null;

            if (!string.IsNullOrWhiteSpace(partIdInput))
            {
                if (!int.TryParse(partIdInput, out int parsedPartId))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Part ID");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }

                var partService = new PartService(_context);
                var foundPart = await partService.GetPart(parsedPartId);

                if (foundPart == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Part not found");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }

                partId = parsedPartId;
            }

            
            Console.Write("Write the detail description: ");
            string description = FormCustomers.VerifyFieldString("description");

            
            Console.Write("Write the cost: ");
            string costInput = FormCustomers.VerifyFieldString("cost");

            if (!decimal.TryParse(costInput, out decimal cost))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid cost");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }
            
            var newDetail = new RepairDetail
            {
                RepairId = repairId,
                Description = description,
                Cost = cost,
                PartId = partId
            };
            
            
            var detailService = new RepairDetailService(_context);
            await detailService.AddRepairDetail(newDetail);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Repair Detail registered successfully!");
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
