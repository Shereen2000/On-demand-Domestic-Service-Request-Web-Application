using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.Server.Data;
using ServiceSphere.Server.Models;
using ServiceSphere.Server.QueryObjects;


namespace ServiceSphere.Server.Repositories
{
    public class AvailableRepo : IAvailableRepo
    {
        private readonly ApplicationDbContext _context;
        public AvailableRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Available> AddAsync(Available available)
        {
            if (available == null)
            {
                return null;
            }

            await _context.Availables.AddAsync(available);

            await _context.SaveChangesAsync();

            return available;
        }

        public async Task<Available> DeleteAsync(int Id)
        {
            var available = await _context.Availables.FirstOrDefaultAsync(a => a.Id == Id);

            if (available == null)
            {
                return null;
            }

            _context.Availables.Remove(available);
            await _context.SaveChangesAsync();

            return available; 
        }

        public async Task<Available> GetByIdAsync(int Id)
        {
             return await _context.Availables
                .AsNoTracking() 
                .FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<List<Available>> QueryAvailableAsync(AvailableQueryObject query)
        {
            var availabilityQuery = _context.Availables.Include(a => a.Worker).AsQueryable();

            // Filter by WorkerId if provided
            if (query.WorkerId.HasValue)
            {
                availabilityQuery = availabilityQuery.Where(a => a.WorkerId == query.WorkerId.Value);
            }

            // Filter by Day if provided
            if (query.Day.HasValue)
            {
                availabilityQuery = availabilityQuery.Where(a => a.Day == query.Day.Value);
            }

            // Filter by Reserved status if provided
            if (query.Reserved.HasValue)
            {
                availabilityQuery = availabilityQuery.Where(a => a.Reserved == query.Reserved.Value);
            }

            // Filter by AreaGroupId if provided
            if (query.AreaGroupId.HasValue)
            {
                availabilityQuery = availabilityQuery.Where(a => a.Worker.WorkerAreaGroups.Any(wag => wag.AreaGroupId == query.AreaGroupId.Value));
            }

             // Filter by ServiceId if provided
            if (query.ServiceId.HasValue)
            {
                availabilityQuery = availabilityQuery.Where(a => a.Worker.ServiceId == query.ServiceId.Value);
            }

            return await availabilityQuery.ToListAsync();
        }

        public async Task<Available> UpdateAsync(Available available)
        {
            var existingAvailable = await _context.Availables.FirstOrDefaultAsync(a => a.Id == available.Id);

            if (existingAvailable == null)
            {
                return null; // Available entry not found
            }

            _context.Entry(existingAvailable).CurrentValues.SetValues(available);


            await _context.SaveChangesAsync();

            return existingAvailable;
        }
    }
}