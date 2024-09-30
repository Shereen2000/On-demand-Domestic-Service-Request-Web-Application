using Microsoft.EntityFrameworkCore;
using ServiceSphere.Server.Data;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Repositories
{
    public class BookingRepo : IBookingRepo
    {
        private readonly ApplicationDbContext _context;

        public BookingRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieves a Booking by its ID, including related entities
        public async Task<Booking> GetByIdAsync(int Id)
        {
            return await _context.Bookings
                .Include(b => b.Service) // Include related Service
                .Include(b => b.Client) // Include related Client
                .Include(b => b.Worker) // Include related Worker
                .Include(b => b.Review) // Include related Review
                .AsNoTracking() // Improve performance for read-only operations
                .FirstOrDefaultAsync(b => b.Id == Id);
        }

        // Updates an existing Booking and returns the updated Booking
        public async Task<Booking> UpdateAsync(Booking booking)
        {
            var existingBooking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == booking.Id);

            if (existingBooking == null)
            {
                return null; // Booking not found
            }

           _context.Entry(existingBooking).CurrentValues.SetValues(booking);

            await _context.SaveChangesAsync();

            return existingBooking;
        }

        // Deletes a Booking by its ID and returns the deleted Booking
        public async Task<Booking> DeleteAsync(int Id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == Id);

            if (booking == null)
            {
                return null; // Booking not found
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return booking; // Return the deleted Booking
        }

        public async Task<Booking> AddAsync(Booking booking)
        {
            if (booking == null)
            {
                return null;
            }

            await _context.Bookings.AddAsync(booking);

            await _context.SaveChangesAsync();

            return booking;
        }
    }
}
