using Microsoft.EntityFrameworkCore;
using ServiceSphere.Server.Data;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Repositories
{
    public class CityRepo : ICityRepo
    {
        private readonly ApplicationDbContext _context;

        public CityRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<City> GetByIdAsync(int Id)
        {
                    return await _context.Cities
                .Include(c => c.AreaGroups) // Include related AreaGroups
                    .ThenInclude(ag => ag.Areas) // Include Areas within each AreaGroup
                .AsNoTracking() // Improve performance for read-only operations
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<City> UpdateAsync(City city)
        {
            if (city == null)
            {
                return null;
            }

            // Check if the worker exists
            var existingCity = await _context.Cities.FindAsync(city.Id);
            if (existingCity == null)
            {
                throw new KeyNotFoundException("City not found.");
            }

            // Update properties (if needed) - This can be handled automatically by EF Core
            _context.Entry(existingCity).CurrentValues.SetValues(city);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the updated worker
            return existingCity;
        }

        public async Task<City> DeleteAsync(int Id)
        {
            var city = await _context.Cities
            .Include(c => c.AreaGroups)
            .ThenInclude(ag => ag.Areas)
            .FirstOrDefaultAsync(c => c.Id == Id);

            if (city == null)
            {
                return null; 
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return city; 
        }

        public async Task<City> AddAsync(City city)
        {
             if (city == null)
            {
                return null;
            }

            // Add the worker to the context
            await _context.Cities.AddAsync(city);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the added worker (with its generated Id)
            return city;
        }

        public async Task<List<City>> GetAllAsync()
        {
              return await _context.Cities
                .Include(c => c.AreaGroups) // Include related AreaGroups
                    .ThenInclude(ag => ag.Areas)
                    .ToListAsync();
        }
    }
}
