using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Repositories
{
    public interface IServiceRepo
    {
        Task<Service> GetByIdAsync(int id); // Get specific Service by ID
        Task<List<Service>> GetAllAsync(); // Get all Services
        Task<Service> AddAsync(Service service); // Add a new Service
        Task<Service> DeleteAsync(int id); // Delete a Service by ID
    }
}