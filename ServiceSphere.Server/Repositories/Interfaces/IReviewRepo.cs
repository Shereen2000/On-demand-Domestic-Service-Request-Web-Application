using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;


namespace ServiceSphere.Server.Repositories
{
    public interface IReviewRepo
    {
        Task<Review> GetByIdAsync(int id); // Get specific Review by ID

        Task<Review> AddAsync(Review review); // Add a new Review
        Task<Review> DeleteAsync(int id); // Delete a Review by ID
    }
}