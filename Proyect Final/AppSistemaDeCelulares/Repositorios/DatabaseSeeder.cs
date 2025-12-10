using AppSistemaDeCelulares.Data;
using AppSistemaDeCelulares.Models;

namespace AppSistemaDeCelulares.Helpers.Seed;

public class DatabaseSeeder
{
    private readonly ApplicationDbContext _context;

    public DatabaseSeeder(ApplicationDbContext context)
    {
        _context = context;
    }

    public  async Task SeedAllData()
    {
        try
        {
            
            if (_context.Customers.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚠️  Database already contains data. Skipping seed.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("🌱 Seeding database with demo data...");

            await SeedCustomers();
            await SeedTechnicians();
            await SeedParts();
            await SeedPhoneDevices();
            await SeedDiagnostics();
            await SeedRepairs();
            await SeedRepairDetails();
            await SeedDeliveries();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✅ Database seeded successfully!");
            Console.ResetColor();
            Console.WriteLine("\nDemo data created:");
            Console.WriteLine($"  • {_context.Customers.Count()} Customers");
            Console.WriteLine($"  • {_context.Technicians.Count()} Technicians");
            Console.WriteLine($"  • {_context.Parts.Count()} Parts");
            Console.WriteLine($"  • {_context.PhoneDevices.Count()} Phone Devices");
            Console.WriteLine($"  • {_context.Diagnostics.Count()} Diagnostics");
            Console.WriteLine($"  • {_context.Repairs.Count()} Repairs");
            Console.WriteLine($"  • {_context.RepairDetails.Count()} Repair Details");
            Console.WriteLine($"  • {_context.Deliveries.Count()} Deliveries");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ Error seeding database: {ex.Message}");
            Console.ResetColor();
            throw;
        }
    }

    private async Task SeedCustomers()
    {
        var customers = new List<Customer>
        {
            new Customer
            {
                Name = "Juan Pérez",
                Phone = "809-555-0101",
                Email = "juan.perez@email.com",
                Address = "Calle Principal #123, Santo Domingo",
                DateRegister = DateTime.Now.AddMonths(-6)
            },
            new Customer
            {
                Name = "María García",
                Phone = "809-555-0102",
                Email = "maria.garcia@email.com",
                Address = "Av. Lincoln #456, Santo Domingo",
                DateRegister = DateTime.Now.AddMonths(-4)
            },
            new Customer
            {
                Name = "Carlos Rodríguez",
                Phone = "809-555-0103",
                Email = "carlos.rod@email.com",
                Address = "Calle El Sol #789, Santiago",
                DateRegister = DateTime.Now.AddMonths(-3)
            },
            new Customer
            {
                Name = "Ana Martínez",
                Phone = "809-555-0104",
                Email = "ana.martinez@email.com",
                Address = "Av. Duarte #321, La Vega",
                DateRegister = DateTime.Now.AddMonths(-2)
            },
            new Customer
            {
                Name = "Luis Fernández",
                Phone = "809-555-0105",
                Email = "luis.fernandez@email.com",
                Address = "Calle Restauración #654, San Pedro",
                DateRegister = DateTime.Now.AddMonths(-1)
            }
        };

        await _context.Customers.AddRangeAsync(customers);
        await _context.SaveChangesAsync();
        Console.WriteLine("  ✓ Customers seeded");
    }

    private async Task SeedTechnicians()
    {
        var technicians = new List<Technician>
        {
            new Technician
            {
                Name = "Pedro Sánchez",
                Specialty = "Reparación de pantallas y baterías",
                Phone = "809-555-0201"
            },
            new Technician
            {
                Name = "Laura Jiménez",
                Specialty = "Reparación de placas y componentes electrónicos",
                Phone = "809-555-0202"
            },
            new Technician
            {
                Name = "Roberto Díaz",
                Specialty = "Software y liberación de equipos",
                Phone = "809-555-0203"
            }
        };

        await _context.Technicians.AddRangeAsync(technicians);
        await _context.SaveChangesAsync();
        Console.WriteLine("  ✓ Technicians seeded");
    }

    private async Task SeedParts()
    {
        var parts = new List<Part>
        {
            new Part { Name = "Pantalla LCD", Price = 2500.00m, StockQuantity = 15 },
            new Part { Name = "Batería", Price = 800.00m, StockQuantity = 25 },
            new Part { Name = "Placa madre", Price = 4500.00m, StockQuantity = 8 },
            new Part { Name = "Cámara", Price = 1200.00m, StockQuantity = 12 },
            new Part { Name = "Flex", Price = 300.00m, StockQuantity = 30 },
            new Part { Name = "Altavoz", Price = 250.00m, StockQuantity = 20 },
            new Part { Name = "Micrófono", Price = 200.00m, StockQuantity = 18 },
            new Part { Name = "Conector carga", Price = 350.00m, StockQuantity = 22 },
            new Part { Name = "Botón power", Price = 150.00m, StockQuantity = 25 },
            new Part { Name = "Touch screen", Price = 1800.00m, StockQuantity = 10 }
        };

        await _context.Parts.AddRangeAsync(parts);
        await _context.SaveChangesAsync();
        Console.WriteLine("  ✓ Parts seeded");
    }

    private async Task SeedPhoneDevices()
    {
        var customers = _context.Customers.ToList();

        var phones = new List<PhoneDevice>
        {
            new PhoneDevice
            {
                Brand = "Samsung",
                Model = "Galaxy S21",
                IMEI = "356789012345678",
                Color = "Negro",
                Status = "En reparación",
                CheckInDate = DateTime.Now.AddDays(-5),
                CustomerId = customers[0].CustomerId
            },
            new PhoneDevice
            {
                Brand = "iPhone",
                Model = "13 Pro",
                IMEI = "356789012345679",
                Color = "Azul",
                Status = "Diagnóstico",
                CheckInDate = DateTime.Now.AddDays(-3),
                CustomerId = customers[1].CustomerId
            },
            new PhoneDevice
            {
                Brand = "Xiaomi",
                Model = "Redmi Note 11",
                IMEI = "356789012345680",
                Color = "Blanco",
                Status = "Completado",
                CheckInDate = DateTime.Now.AddDays(-10),
                CustomerId = customers[2].CustomerId
            },
            new PhoneDevice
            {
                Brand = "Motorola",
                Model = "Moto G60",
                IMEI = "356789012345681",
                Color = "Verde",
                Status = "Entregado",
                CheckInDate = DateTime.Now.AddDays(-15),
                CustomerId = customers[3].CustomerId
            },
            new PhoneDevice
            {
                Brand = "Samsung",
                Model = "Galaxy A52",
                IMEI = "356789012345682",
                Color = "Morado",
                Status = "Pendiente",
                CheckInDate = DateTime.Now.AddDays(-1),
                CustomerId = customers[4].CustomerId
            }
        };

        await _context.PhoneDevices.AddRangeAsync(phones);
        await _context.SaveChangesAsync();
        Console.WriteLine("  ✓ Phone Devices seeded");
    }

    private async Task SeedDiagnostics()
    {
        var phones = _context.PhoneDevices.ToList();
        var technicians = _context.Technicians.ToList();

        var diagnostics = new List<Diagnostic>
        {
            new Diagnostic
            {
                PhoneDeviceId = phones[0].PhoneDeviceId,
                TechnicianId = technicians[0].TechnicianId,
                Description = "Pantalla rota, touch no funciona. Batería hinchada.",
                Date = DateTime.Now.AddDays(-5),
                EstimatedCost = 3500.00m
            },
            new Diagnostic
            {
                PhoneDeviceId = phones[1].PhoneDeviceId,
                TechnicianId = technicians[1].TechnicianId,
                Description = "No enciende, posible problema en placa madre.",
                Date = DateTime.Now.AddDays(-3),
                EstimatedCost = 5000.00m
            },
            new Diagnostic
            {
                PhoneDeviceId = phones[2].PhoneDeviceId,
                TechnicianId = technicians[2].TechnicianId,
                Description = "Software corrupto, requiere flasheo completo.",
                Date = DateTime.Now.AddDays(-10),
                EstimatedCost = 800.00m
            }
        };

        await _context.Diagnostics.AddRangeAsync(diagnostics);
        await _context.SaveChangesAsync();
        Console.WriteLine("  ✓ Diagnostics seeded");
    }

    private async Task SeedRepairs()
    {
        var phones = _context.PhoneDevices.ToList();
        var technicians = _context.Technicians.ToList();

        var repairs = new List<Repair>
        {
            new Repair
            {
                PhoneDeviceId = phones[0].PhoneDeviceId,
                TechnicianId = technicians[0].TechnicianId,
                StartDate = DateTime.Now.AddDays(-4),
                EndDate = null,
                LaborCost = 1000.00m,
                Status = "En proceso"
            },
            new Repair
            {
                PhoneDeviceId = phones[2].PhoneDeviceId,
                TechnicianId = technicians[2].TechnicianId,
                StartDate = DateTime.Now.AddDays(-9),
                EndDate = DateTime.Now.AddDays(-7),
                LaborCost = 500.00m,
                Status = "Completado"
            },
            new Repair
            {
                PhoneDeviceId = phones[3].PhoneDeviceId,
                TechnicianId = technicians[0].TechnicianId,
                StartDate = DateTime.Now.AddDays(-14),
                EndDate = DateTime.Now.AddDays(-12),
                LaborCost = 600.00m,
                Status = "Completado"
            }
        };

        await _context.Repairs.AddRangeAsync(repairs);
        await _context.SaveChangesAsync();
        Console.WriteLine("  ✓ Repairs seeded");
    }

    private async Task SeedRepairDetails()
    {
        var repairs = _context.Repairs.ToList();
        var parts = _context.Parts.ToList();

        var repairDetails = new List<RepairDetail>
        {
            new RepairDetail
            {
                RepairId = repairs[0].RepairId,
                Description = "Reemplazo de pantalla LCD",
                PartId = parts[0].PartId,
                Cost = parts[0].Price
            },
            new RepairDetail
            {
                RepairId = repairs[0].RepairId,
                Description = "Reemplazo de batería",
                PartId = parts[1].PartId,
                Cost = parts[1].Price
            },
            new RepairDetail
            {
                RepairId = repairs[1].RepairId,
                Description = "Instalación de software y configuración",
                PartId = null,
                Cost = 0m
            },
            new RepairDetail
            {
                RepairId = repairs[2].RepairId,
                Description = "Cambio de conector de carga",
                PartId = parts[7].PartId,
                Cost = parts[7].Price
            }
        };

        await _context.RepairDetails.AddRangeAsync(repairDetails);
        await _context.SaveChangesAsync();
        Console.WriteLine("  ✓ Repair Details seeded");
    }

    private async Task SeedDeliveries()
    {
        var phones = _context.PhoneDevices
            .Where(p => p.Status == "Entregado")
            .ToList();

        if (phones.Any())
        {
            var delivery = new Delivery
            {
                PhoneDeviceId = phones[0].PhoneDeviceId,
                DeliveryDate = DateTime.Now.AddDays(-2),
                TotalAmount = 1500.00m,
                Notes = "Equipo entregado en perfecto estado. Cliente satisfecho."
            };

            await _context.Deliveries.AddAsync(delivery);
            await _context.SaveChangesAsync();
            Console.WriteLine("  ✓ Deliveries seeded");
        }
    }

    // Método para limpiar todos los datos
    public async Task ClearAllData()
    {
        try
        {
            Console.WriteLine("🗑️  Clearing all data from database...");

            _context.RepairDetails.RemoveRange(_context.RepairDetails);
            _context.Deliveries.RemoveRange(_context.Deliveries);
            _context.Repairs.RemoveRange(_context.Repairs);
            _context.Diagnostics.RemoveRange(_context.Diagnostics);
            _context.PhoneDevices.RemoveRange(_context.PhoneDevices);
            _context.Parts.RemoveRange(_context.Parts);
            _context.Technicians.RemoveRange(_context.Technicians);
            _context.Customers.RemoveRange(_context.Customers);

            await _context.SaveChangesAsync();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ All data cleared successfully!");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ Error clearing data: {ex.Message}");
            Console.ResetColor();
            throw;
        }
    }
}