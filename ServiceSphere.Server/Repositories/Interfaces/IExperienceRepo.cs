using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Repositories
{
    public interface IExperienceRepo
    {
        Task<Experience> GetByIdAsync(int Id); // Retrieve an Experience by ID
        Task<Experience> UpdateAsync(Experience experience); // Update an Experience
        Task<Experience> AddAsync(Experience experience); // Add a new Experience
        Task<Experience> DeleteAsync(int Id); // Delete an Experience
    }
}