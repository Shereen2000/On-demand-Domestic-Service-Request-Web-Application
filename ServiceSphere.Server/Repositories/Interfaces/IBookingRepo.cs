using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Repositories
{
    public interface IBookingRepo
    {
        Task<Booking> GetByIdAsync(int Id); // Retrieve a Booking by ID
        Task<Booking> UpdateAsync(Booking booking); // Update a Booking
        Task<Booking> AddAsync(Booking booking); // Add a new Booking
        Task<Booking> DeleteAsync(int Id); // Delete a Booking
    }
}