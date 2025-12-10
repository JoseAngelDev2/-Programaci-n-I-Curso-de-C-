using AppSistemaDeCelulares.Models;
using Microsoft.EntityFrameworkCore;
using AppDb = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Service
{
    public class RepairDetailService
    {
        private readonly AppDb _db;

        public RepairDetailService(AppDb db)
        {
            _db = db;
        }


        public async Task<List<RepairDetail>> GetAllRepairDetails()
        {
            return await _db.RepairDetails
                .Include(rd => rd.Part)
                .Include(rd => rd.Repair)
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<RepairDetail?> GetRepairDetail(int id)
        {
            return await _db.RepairDetails
                .Include(rd => rd.Part)
                .Include(rd => rd.Repair)
                .FirstOrDefaultAsync(rd => rd.RepairDetailId == id);
        }

   
        public async Task<List<RepairDetail>> GetRepairDetailsByRepair(int repairId)
        {
            return await _db.RepairDetails
                .Where(rd => rd.RepairId == repairId)
                .Include(rd => rd.Part)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddRepairDetail(RepairDetail detail)
        {
            await _db.RepairDetails.AddAsync(detail);
            await _db.SaveChangesAsync();
        }

  
        public async Task UpdateRepairDetail(RepairDetail detail)
        {
            _db.RepairDetails.Update(detail);
            await _db.SaveChangesAsync();
        }
        
        public async Task RemoveRepairDetail(RepairDetail detail)
        {
            _db.RepairDetails.Remove(detail);
            await _db.SaveChangesAsync();
        }
    }
}
