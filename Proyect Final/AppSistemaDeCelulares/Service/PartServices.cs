using AppSistemaDeCelulares.Models;
using Microsoft.EntityFrameworkCore;
using AppDb = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Service
{
    public class PartService
    {
        private readonly AppDb _db;

        public PartService(AppDb db)
        {
            _db = db;
        }

        public async Task<List<Part>> GetAllParts()
        {
            return await _db.Parts
                .Include(p => p.ListRepairDetails)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Part?> GetPart(int id)
        {
            return await _db.Parts
                .Include(p => p.ListRepairDetails)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PartId == id);
        }

        public async Task AddPart(Part part)
        {
            _db.Parts.Add(part);
            await _db.SaveChangesAsync();
        }

        public async Task UpdatePart(Part part)
        {
            _db.Parts.Update(part);
            await _db.SaveChangesAsync();
        }

        public async Task RemovePart(Part part)
        {
            _db.Parts.Remove(part);
            await _db.SaveChangesAsync();
        }
    }
}