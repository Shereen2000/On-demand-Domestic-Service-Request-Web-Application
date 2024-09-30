using Microsoft.EntityFrameworkCore;
using ServiceSphere.Server.Data;
using ServiceSphere.Server.Models;


namespace ServiceSphere.Server.Repositories
{
    // Repository class for managing Area entities
    public class AreaRepo : IAreaRepo
    {
        // ApplicationDbContext instance for database operations
        private readonly ApplicationDbContext _context;

        // Constructor that takes ApplicationDbContext as a parameter
        public AreaRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Area> AddAsync(Area area)
        {
            if (area == null)
            {
                return null;
            }

            await _context.Areas.AddAsync(area);

            await _context.SaveChangesAsync();

            return area;
        }

        public async Task<Area> DeleteAsync(int Id)
        {
            var area = await _context.Areas.FirstOrDefaultAsync(s => s.Id == Id);

            if (area == null)
            {
                return null; 
            }

            _context.Areas.Remove(area);

            await _context.SaveChangesAsync();

            return area;
        }

        public async Task<List<Area>> GetByAreaGroupAsync(int areaGroupId)
        {
            return await _context.Areas
            .Where(a => a.AreaGroupId == areaGroupId)
            .ToListAsync();
        }

        public async Task<List<Area>> GetByCityAsync(int cityId)
        {
            return await _context.Areas
            .Where(a => a.AreaGroup.CityId == cityId)
            .ToListAsync();
        }

        public async Task<Area> GetByIdAsync(int Id)
        {
            return await _context.Areas.AsNoTracking().FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<Area> UpdateAsync(Area area)
        {
            var existingArea = await _context.Areas.FirstOrDefaultAsync(s => s.Id == area.Id);
    
            if (existingArea == null)
            {
                return null; 
            }

             _context.Entry(existingArea).CurrentValues.SetValues(area);

            await _context.SaveChangesAsync();

            return existingArea;
        }
    }
}
