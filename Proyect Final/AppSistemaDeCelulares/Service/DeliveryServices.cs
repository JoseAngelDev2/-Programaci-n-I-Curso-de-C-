using AppSistemaDeCelulares.Models;
using Microsoft.EntityFrameworkCore;
using AppDb = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Service
{
    public class DeliveryService
    {
        private readonly AppDb _db;

        public DeliveryService(AppDb db)
        {
            _db = db;
        }

        public async Task<Delivery> GetDelivery(int id)
        {
            var deli = _db.Deliveries.Where(d => d.DeliveryId == id)
                .Include(d => d.PhoneDevice)
                .FirstOrDefault();

            return deli;

        }

        public async Task AddDelivery(Delivery delivery)
        {
            try
            {
                _db.Deliveries.Add(delivery); // EF Core genera DeliveryId automáticamente
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error adding delivery: " + e.Message, e);
            }
        }

        public async Task<List<Delivery>> GetAllDeliveries()
        {
            return await _db.Deliveries
                .Include(d => d.PhoneDevice)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task DeleteDelivery(Delivery delivery)
        {
            _db.Deliveries.Remove(delivery);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveDelivery(Delivery delivery)
        {
            _db.Deliveries.Remove(delivery);
            _db.Entry(delivery).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
        }
    }
}