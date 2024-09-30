using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;


namespace ServiceSphere.Server.Repositories
{
    public interface ITaskBookingRepo
    {
        Task<Booking> GetByIdAsync(int id); // Get specific Review by ID

        Task<Booking> AddAsync(Review review); // Add a new Review
        Task<Booking> DeleteAsync(int id); // Delete a Review by ID
    }
}