using Microsoft.EntityFrameworkCore;
using ServiceSphere.Server.Data;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Repositories
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieve a specific Service by ID
        public async Task<Service> GetByIdAsync(int id)
        {
            return await _context.Services
                .Include(s => s.Tasks) // Include related ServiceTasks
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // Get all Services
        public async Task<List<Service>> GetAllAsync()
        {
            return await _context.Services
                .Include(s => s.Tasks) // Include related ServiceTasks
                .ToListAsync();
        }

        // Add a new Service
        public async Task<Service> AddAsync(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
            return service; // Return the added Service
        }

        // Delete a Service by its ID
        public async Task<Service> DeleteAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return null; // Service not found
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return service; // Return the deleted Service
        }
    }
}
