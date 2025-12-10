using AppSistemaDeCelulares.Models;
using Microsoft.EntityFrameworkCore;
using AppDiagnostic = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Service
{
    public class DiagnosticServices
    {
        private readonly AppDiagnostic _db;

        public DiagnosticServices(AppDiagnostic db)
        {
            _db = db;
        }
        
        public async Task<List<Diagnostic>> ListDiagnostics()
        {
            return await _db.Diagnostics
                .Include(d => d.PhoneDevice)      
                .Include(d => d.Technician)        
                .Include(d => d.ListRepairDetails) 
                .AsNoTracking()
                .ToListAsync();
        }

        
        public async Task<Diagnostic?> GetDiagnostic(int id)
        {
            return await _db.Diagnostics
                .Include(d => d.PhoneDevice)
                .Include(d => d.Technician)
                .Include(d => d.ListRepairDetails)
                .FirstOrDefaultAsync(d => d.DiagnosisId == id);
        }

        
        public async Task AddDiagnostic(Diagnostic diagnostic)
        {
            await _db.Diagnostics.AddAsync(diagnostic);
            await _db.SaveChangesAsync();
        }

        
        public async Task UpdateDiagnostic(Diagnostic diagnostic)
        {
            _db.Diagnostics.Update(diagnostic);
            await _db.SaveChangesAsync();
        }
        
        public async Task RemoveDiagnostic(Diagnostic diagnostic)
        {
            _db.Diagnostics.Remove(diagnostic);
            await _db.SaveChangesAsync();
        }
    }
}
