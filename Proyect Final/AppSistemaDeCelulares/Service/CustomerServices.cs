using AppSistemaDeCelulares.Data;
using AppSistemaDeCelulares.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AppCustomer = AppSistemaDeCelulares.Data.ApplicationDbContext;
using Index = System.Index;

namespace AppSistemaDeCelulares.Service;
public class  CustomerServices
{
    private readonly AppCustomer _db;

    public CustomerServices(AppCustomer db)
    {
        _db = db;
    }
    
    public List<Customer> GetAllCustomers()
    {
        return _db.Customers
            .Include(x => x.PhoneDevices)
            .AsNoTracking()
            .ToList();
    }

    public async Task<Customer?> GetCustomer(int id)
    {
        var customer = await _db.Customers
            .Where(c => c.CustomerId == id)
            .Include(d => d.PhoneDevices)
            .FirstOrDefaultAsync();

        return customer;
    }
    public async Task ListAddPhoneDevices(int id, PhoneDevice phone)
    {
        var customer = await _db.Customers
            .Include(x => x.PhoneDevices)
            .FirstOrDefaultAsync(c => c.CustomerId == id);

        if (customer is null) { Console.WriteLine("Customer not found") ; return; }
        phone.CustomerId = id;
        _db.PhoneDevices.Add(phone);
        await _db.SaveChangesAsync();

    }
    
    public async Task AddCustomer(Customer customer)
    {
        await _db.Customers.AddAsync(customer);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateCustomer(Customer customer)
    {
        
        _db.Entry(customer).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task RemoveCustomer(Customer customer)
    {
        _db.Customers.Remove(customer);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveAllCustomers()
    {
     
        _db.Customers.RemoveRange(await _db.Customers.ToListAsync());
        await _db.SaveChangesAsync();
        await _db.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Customers', RESEED, 0)");
    }
}

