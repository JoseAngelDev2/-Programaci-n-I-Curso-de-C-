using AppSistemaDeCelulares.Models;
using Microsoft.EntityFrameworkCore;
using AppRepair = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Service;

public class AppRepairService
{
    private readonly AppRepair _db;

    public AppRepairService(AppRepair db)
    {
        _db = db;
    }

    public async Task<List<Repair>> GetAllRepairs()
    {
        return await _db.Repairs
            .Include(r => r.ListRepairDetails)
            .Include(r => r.PhoneDevice)
            .Include(r => r.Technician)
            .AsNoTracking()
            .ToListAsync();
    }

  
    public async Task<Repair?> GetRepair(int id)
    {
        return await _db.Repairs
            .Include(r => r.ListRepairDetails)
            .Include(r => r.PhoneDevice)
            .Include(r => r.Technician)
            .FirstOrDefaultAsync(r => r.RepairId == id);
    }


    public async Task AddRepair(Repair repair)
    {
        await _db.Repairs.AddAsync(repair);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateRepair(Repair repair)
    {
        _db.Repairs.Update(repair);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveRepair(Repair repair)
    {
        _db.Repairs.Remove(repair);
        await _db.SaveChangesAsync();
    }
}