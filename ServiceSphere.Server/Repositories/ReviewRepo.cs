using Microsoft.EntityFrameworkCore;
using ServiceSphere.Server.Data;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Repositories
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieve a specific Review by ID
        public async Task<Review> GetByIdAsync(int id)
        {
            return await _context.Reviews
                .Include(r => r.Booking) // Include related Booking
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        // Add a new Review
        public async Task<Review> AddAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return review; // Return the added Review
        }

        // Delete a Review by its ID
        public async Task<Review> DeleteAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return null; // Review not found
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return review; // Return the deleted Review
        }
    }
}
