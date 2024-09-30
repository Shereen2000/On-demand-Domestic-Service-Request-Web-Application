using Microsoft.EntityFrameworkCore;
using ServiceSphere.Server.Data;
using ServiceSphere.Server.Models;
using ServiceSphere.Server.QueryObjects;

namespace ServiceSphere.Server.Repositories
{
    public class ClientRepo : IClientRepo
    {
        private readonly ApplicationDbContext _context;

        public ClientRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieves a Client by its ID, including related Bookings
        public async Task<Client> GetByIdAsync(int Id)
        {
            return await _context.Clients
                .Include(c => c.Bookings) // Include related Bookings
                .AsNoTracking() // Improve performance for read-only operations
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        // Deletes a Client by its ID and returns the deleted Client
        public async Task<Client> DeleteAsync(int Id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == Id);

            if (client == null)
            {
                return null; // Client not found
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return client; // Return the deleted Client
        }

        public Task<Client> AddAsync(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
