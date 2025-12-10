using System.Reflection;
using AppSistemaDeCelulares.Models;
using Microsoft.EntityFrameworkCore;

namespace AppSistemaDeCelulares.Data;

public class ApplicationDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=CellPhonesDB;Trusted_Connection=True;TrustServerCertificate=True;";
        optionsBuilder.UseSqlServer(connectionString); 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    public DbSet<Diagnostic> Diagnostics { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PhoneDevice> PhoneDevices { get; set;} 
    public DbSet<Technician> Technicians { get; set; }
    public DbSet<Repair> Repairs { get; set; }
    public DbSet<RepairDetail> RepairDetails { get; set; }
    public DbSet<Part> Parts { get; set; }
    public DbSet<Delivery> Deliveries { get; set; } 
}
    
