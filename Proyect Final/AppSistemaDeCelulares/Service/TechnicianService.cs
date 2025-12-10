using AppSistemaDeCelulares.Models;
using Microsoft.EntityFrameworkCore;
using AppTechnician = AppSistemaDeCelulares.Data.ApplicationDbContext;
namespace AppSistemaDeCelulares.Service;

public class AppTechnicianServices
{
    private readonly AppTechnician _db;

    public AppTechnicianServices(AppTechnician db)
    {
        _db = db;
    }
    
    public async Task<Technician> GetTechnician(int id)
    {
        var tech = _db.Technicians
            .Where(t=> t.TechnicianId == id )
            .Include(t => t.Diagnoses)
            .Include(t => t.Repairs)
            .FirstOrDefault();

        return tech;

    }
    
    public List<Technician> GetAllTechnician()
    { 
        return _db.Technicians
           .Include(t => t.Repairs)
           .Include(t => t.Diagnoses)
           .AsNoTracking()
           .ToList();
    }

    public async Task AddTechnician(Technician technician)
    {
        await _db.Technicians.AddAsync(technician);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateTechnian(Technician technician)
    {
        _db.Technicians.Entry(technician).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        
    }

    public async Task RemoveTechnician(Technician technician)
    {
        _db.Technicians.Remove(technician);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveAllTechnician(Technician technician)
    {
        _db.Technicians.RemoveRange(technician);
        await _db.SaveChangesAsync();
        await _db.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Technicians', RESEED, 0)");
    }

}