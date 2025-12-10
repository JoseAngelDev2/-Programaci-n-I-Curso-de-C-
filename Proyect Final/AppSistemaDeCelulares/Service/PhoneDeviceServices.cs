
using AppSistemaDeCelulares.Data;
using AppSistemaDeCelulares.Models;
using Microsoft.EntityFrameworkCore;
using AppPhoneDevice = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Service;

public class PhoneDeviceServices
{
    private readonly AppPhoneDevice _db;

    public PhoneDeviceServices(AppPhoneDevice db)
    {
        _db = db;
    }
    
    public List<PhoneDevice> GetAllPhoneDevices()
    {
        return _db.PhoneDevices
            .Include(p => p.Diagnostics)
            .Include(p => p.Repairs )
            .Include(p => p.Delivery)
            .Include(p => p.Customer)
            .AsNoTracking()
            .ToList();
    }
    
    public async Task<PhoneDevice?> GetPhoneDevice(int id)
    {
        var device = await _db.PhoneDevices
            .Include(d => d.Diagnostics)
            .Include(d => d.Repairs)
            .FirstOrDefaultAsync(d => d.PhoneDeviceId == id);
        return device;
    }
    
    public async Task AddPhoneDevide(PhoneDevice phone)
    {
        await _db.PhoneDevices.AddAsync(phone);
        await _db.SaveChangesAsync();
    }

    public async Task UpdatePhoneDevide(PhoneDevice phone)
    {
        _db.Entry(phone).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task RemovePhoneDevide(PhoneDevice device)
    {
        _db.PhoneDevices.Remove(device);
        await _db.SaveChangesAsync();
    }
}