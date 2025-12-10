using System.Reflection.Metadata;
using AppSistemaDeCelulares.Models;
using AppCustomer = AppSistemaDeCelulares.Data.ApplicationDbContext;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Document = iText.Layout.Document;

namespace AppSistemaDeCelulares.Helpers
{
    public static class PhoneHistoryPdfGenerator
    {
        public static void GeneratePdf(AppCustomer context, PhoneDevice phone)
        {
            try
            {
                if (context == null) throw new ArgumentNullException(nameof(context));
                if (phone == null) throw new ArgumentNullException(nameof(phone));

                string CleanFileName(string name) => string.IsNullOrWhiteSpace(name) 
                    ? "Campo_vacio" 
                    : string.Join("_", name.Split(System.IO.Path.GetInvalidFileNameChars()));

                string fileName = $"PhoneHistory_{CleanFileName(phone.Brand)}_{CleanFileName(phone.Model)}_{phone.PhoneDeviceId}.pdf";

                using (var writer = new PdfWriter(fileName))
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf);

                    document.Add(new Paragraph("📱 Phone History")
                        .SetFontSize(18)
                        .SetBold()
                        .SetTextAlignment(TextAlignment.CENTER));

                    document.Add(new Paragraph("\n"));

                    // Datos del teléfono
                    document.Add(new Paragraph($"Device: {phone.Brand ?? "Campo vacío"} {phone.Model ?? ""}"));
                    document.Add(new Paragraph($"IMEI: {phone.IMEI ?? "Campo vacío"}"));
                    document.Add(new Paragraph($"Status: {phone.Status ?? "Campo vacío"}"));
                    document.Add(new Paragraph($"Customer ID: {phone.CustomerId}"));
                    document.Add(new Paragraph($"Check-In Date: {phone.CheckInDate.ToShortDateString() ?? "Campo vacío"}"));

                    // Diagnósticos
                    document.Add(new Paragraph("\n🩺 Diagnostics:"));
                    var diagnostics = context.Diagnostics
                        .Where(d => d.PhoneDeviceId == phone.PhoneDeviceId)
                        .ToList();

                    if (diagnostics.Any())
                    {
                        foreach (var diag in diagnostics)
                        {
                            document.Add(new Paragraph($"- {diag.Date.ToShortDateString() ?? "Campo vacío"} | {diag.Description ?? "Campo vacío"} | Est. Cost: {diag.EstimatedCost:C}"));
                        }
                    }
                    else
                    {
                        document.Add(new Paragraph("No se encontraron diagnósticos."));
                    }

                    // Reparaciones
                    document.Add(new Paragraph("\n🔧 Repairs:"));
                    var repairs = context.Repairs
                        .Where(r => r.PhoneDeviceId == phone.PhoneDeviceId)
                        .ToList();

                    if (repairs.Any())
                    {
                        foreach (var repair in repairs)
                        {
                            document.Add(new Paragraph($"- {repair.StartDate.ToShortDateString() ?? "Campo vacío"} -> {repair.EndDate?.ToShortDateString() ?? "En progreso"} | Labor: {repair.LaborCost:C} | Status: {repair.Status ?? "Campo vacío"}"));

                            var details = context.RepairDetails
                                .Where(rd => rd.RepairId == repair.RepairId)
                                .ToList();

                            foreach (var d in details)
                            {
                                string partName = d.PartId.HasValue 
                                    ? context.Parts.FirstOrDefault(p => p.PartId == d.PartId)?.Name ?? "Campo vacío"
                                    : "Campo vacío";

                                document.Add(new Paragraph($"    • {d.Description ?? "Campo vacío"} | Part: {partName} | Cost: {d.Cost:C}"));
                            }
                        }
                    }
                    else
                    {
                        document.Add(new Paragraph("No se encontraron reparaciones."));
                    }

                    // Entregas
                    document.Add(new Paragraph("\n📦 Deliveries:"));
                    var deliveries = context.Deliveries
                        .Where(del => del.PhoneDeviceId == phone.PhoneDeviceId)
                        .ToList();

                    if (deliveries.Any())
                    {
                        foreach (var del in deliveries)
                        {
                            document.Add(new Paragraph($"- {del.DeliveryDate.ToShortDateString() ?? "Campo vacío"} | Total: {del.TotalAmount:C} | Notes: {del.Notes ?? "Campo vacío"}"));
                        }
                    }
                    else
                    {
                        document.Add(new Paragraph("No se encontraron entregas."));
                    }

                    document.Close();
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n✅ PDF generado exitosamente: {fileName}");
                Console.ResetColor();
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Error generando PDF: {ex}");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}
