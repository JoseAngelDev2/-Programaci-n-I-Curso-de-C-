using AppSistemaDeCelulares.Helpers.Forms;
using AppCustomer = AppSistemaDeCelulares.Data.ApplicationDbContext;
using AppSistemaDeCelulares.Service;

namespace AppSistemaDeCelulares.Helpers;

public class DeleteRecord
{
    private static AppCustomer _context = new AppCustomer();

    public static async Task FromDeleteRecord()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("1. Delete Customer");
            Console.WriteLine("2. Delete Phone Device");
            Console.WriteLine("3. Delete Diagnostic");
            Console.WriteLine("4. Delete Repair");
            Console.Write("Select option: ");
            string opt = Console.ReadLine();

            Console.Write("Write the ID to remove: ");
            string inputId = FormCustomers.VerifyFieldString("id");

            if (!int.TryParse(inputId, out int id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ID.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            var cs = new CustomerServices(_context);
            var FoundCustomer = await cs.GetCustomer(id);
            if (FoundCustomer == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Customer not found");
                Console.ReadKey();
                Console.ResetColor();
                return;
            }
            
            switch (opt)
            {
                case "1":
                    
                    await cs.RemoveCustomer(FoundCustomer);
                    break;

                case "2":
                    var ps = new PhoneDeviceServices(_context);
                    var FoundPhone = await ps.GetPhoneDevice(id);
                    if (FoundPhone == null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Device not found");
                        Console.ReadKey();
                        Console.ResetColor();
                        return;
                    }
                    await ps.RemovePhoneDevide(FoundPhone);
                    break;

                case "3":
                    var ds = new DiagnosticServices(_context);
                    var FoundDiagnostic = await ds.GetDiagnostic(id);
                    if (FoundDiagnostic == null)
                    {
                        Console.WriteLine("Diagnostic not found");
                        Console.ReadKey();
                        Console.ResetColor();
                        return;
                    }
                    await ds.RemoveDiagnostic(FoundDiagnostic);
                    break;

                case "4":
                    var rs = new AppRepairService(_context);
                    var foundRepair = await rs.GetRepair(id);
                    
                    if (foundRepair == null)
                    {
                        Console.WriteLine("Diagnostic not found");
                        Console.ReadKey();
                        Console.ResetColor();
                        return;
                    }
                    await rs.RemoveRepair(foundRepair);
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Record deleted successfully!");
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
