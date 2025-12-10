using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AppSistemaDeCelulares.Helpers.Forms;
using AppSistemaDeCelulares.Models;
using AppSistemaDeCelulares.Service;
using AppSistemaDeCelulares.Views;
using AppCustomer = AppSistemaDeCelulares.Data.ApplicationDbContext;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Document = iText.Layout.Document;

namespace AppSistemaDeCelulares.Helpers
{
    public static class ShowPhoneHistoryHelper
    {
        public static async Task      ShowPhoneHistory(AppCustomer context)
        {
            try
            {
                Console.Clear();
                ShowAllPhones.ShowPhones();
                Console.WriteLine("📱 Phone History");
                Console.WriteLine("-------------------------");

                Console.Write("Enter Device ID: ");
                string input = FormCustomers.VerifyFieldString("ID") ?? "";

                PhoneDevice? phone = null;
                PhoneDeviceServices deviceServices = new PhoneDeviceServices(context);
                
                
                if (int.TryParse(input, out int id))
                {
                    phone = await deviceServices.GetPhoneDevice(id);
                }
               

                if (phone == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Device not found.");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }
                

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nDevice: {phone.Brand ?? "N/A"} {phone.Model ?? "N/A"}");
                Console.WriteLine($"IMEI: {phone.IMEI ?? "N/A"}");
                Console.WriteLine($"Status: {phone.Status ?? "N/A"}");
                Console.WriteLine($"Customer ID: {phone.CustomerId}");
                Console.WriteLine($"Check-In Date: {phone.CheckInDate}");
                Console.ResetColor();

                var diagnostics = context.Diagnostics
                    .Where(d => d.PhoneDeviceId == phone.PhoneDeviceId)
                    .ToList();

                Console.WriteLine("\n🩺 Diagnostics:");
                if (diagnostics.Any())
                {
                    foreach (var diag in diagnostics)
                    {
                        Console.WriteLine($"- {diag.Date.ToShortDateString()} | {diag.Description ?? "Empty"} | Est. Cost: {diag.EstimatedCost:C}");
                    }
                }
                else Console.WriteLine("No diagnostics found.");

                var repairs = context.Repairs
                    .Where(r => r.PhoneDeviceId == phone.PhoneDeviceId)
                    .ToList();

                Console.WriteLine("\n🔧 Repairs:");
                if (repairs.Any())
                {
                    foreach (var repair in repairs)
                    {
                        Console.WriteLine($"- {repair.StartDate.ToShortDateString()} -> {repair.EndDate?.ToShortDateString() ?? "In Progress"} | Labor: {repair.LaborCost:C} | Status: {repair.Status ?? "Empty"}");

                        var details = context.RepairDetails
                            .Where(rd => rd.RepairId == repair.RepairId)
                            .ToList();

                        foreach (var d in details)
                        {
                            string partName = d.PartId.HasValue ? context.Parts.Find(d.PartId)?.Name ?? "Empty" : "N/A";
                            Console.WriteLine($"    • {d.Description ?? "Empty"} | Part: {partName} | Cost: {d.Cost:C}");
                        }
                    }
                }
                else Console.WriteLine("No repairs found.");

                var deliveries = context.Deliveries
                    .Where(del => del.PhoneDeviceId == phone.PhoneDeviceId)
                    .ToList();

                Console.WriteLine("\n📦 Deliveries:");
                if (deliveries.Any())
                {
                    foreach (var del in deliveries)
                    {
                        Console.WriteLine($"- {del.DeliveryDate.ToShortDateString()} | Total: {del.TotalAmount:C} | Notes: {del.Notes ?? "Empty"}");
                    }
                }
                else Console.WriteLine("No deliveries found.");

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

                Console.Write("\nDo you want to generate a PDF of this history? (y/n): ");
                string answer = Console.ReadLine() ?? "n";
                if (answer.ToLower() == "y")
                {
                    GeneratePdf(context, phone);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error showing phone history: {ex.Message}");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        private static void GeneratePdf(AppCustomer context, PhoneDevice phone)
        {
            try
            {
                string folderPath = @"C:\Users\uncle\RiderProjects\AppSistemaDeCelulares\AppSistemaDeCelulares\PhoneHistoryPdfs";

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string fileName = Path.Combine(folderPath, $"PhoneHistory_{phone.Brand ?? "Empty"}_{phone.Model ?? "Empty"}_{phone.PhoneDeviceId}.pdf");

                using (var writer = new PdfWriter(fileName))
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf);

                    document.Add(new Paragraph("📱 Phone History")
                        .SetFontSize(18)
                        .SetBold()
                        .SetTextAlignment(TextAlignment.CENTER));

                    document.Add(new Paragraph("\n"));

                    document.Add(new Paragraph($"Device: {phone.Brand ?? "Empty"} {phone.Model ?? "Empty"}"));
                    document.Add(new Paragraph($"IMEI: {phone.IMEI ?? "Empty"}"));
                    document.Add(new Paragraph($"Status: {phone.Status ?? "Empty"}"));
                    document.Add(new Paragraph($"Customer ID: {phone.CustomerId}"));
                    document.Add(new Paragraph($"Check-In Date: {phone.CheckInDate}"));

                    document.Add(new Paragraph("\n🩺 Diagnostics:"));
                    var diagnostics = context.Diagnostics
                        .Where(d => d.PhoneDeviceId == phone.PhoneDeviceId)
                        .ToList();

                    if (diagnostics.Any())
                    {
                        foreach (var diag in diagnostics)
                        {
                            document.Add(new Paragraph($"- {diag.Date.ToShortDateString()} | {diag.Description ?? "Empty"} | Est. Cost: {diag.EstimatedCost:C}"));
                        }
                    }
                    else document.Add(new Paragraph("No diagnostics found."));

                    document.Add(new Paragraph("\n🔧 Repairs:"));
                    var repairs = context.Repairs
                        .Where(r => r.PhoneDeviceId == phone.PhoneDeviceId)
                        .ToList();

                    if (repairs.Any())
                    {
                        foreach (var repair in repairs)
                        {
                            document.Add(new Paragraph($"- {repair.StartDate.ToShortDateString()} -> {repair.EndDate?.ToShortDateString() ?? "In Progress"} | Labor: {repair.LaborCost:C} | Status: {repair.Status ?? "Empty"}"));

                            var details = context.RepairDetails
                                .Where(rd => rd.RepairId == repair.RepairId)
                                .ToList();

                            foreach (var d in details)
                            {
                                string partName = d.PartId.HasValue ? context.Parts.Find(d.PartId)?.Name ?? "Empty" : "N/A";
                                document.Add(new Paragraph($"    • {d.Description ?? "Empty"} | Part: {partName} | Cost: {d.Cost:C}"));
                            }
                        }
                    }
                    else document.Add(new Paragraph("No repairs found."));

                    document.Add(new Paragraph("\n📦 Deliveries:"));
                    var deliveries = context.Deliveries
                        .Where(del => del.PhoneDeviceId == phone.PhoneDeviceId)
                        .ToList();

                    if (deliveries.Any())
                    {
                        foreach (var del in deliveries)
                        {
                            document.Add(new Paragraph($"- {del.DeliveryDate.ToShortDateString()} | Total: {del.TotalAmount:C} | Notes: {del.Notes ?? "Empty"}"));
                        }
                    }
                    else document.Add(new Paragraph("No deliveries found."));

                    document.Close();
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n✅ PDF generated successfully: {fileName}");
                Console.ResetColor();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Error generating PDF: {ex.Message}");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}

