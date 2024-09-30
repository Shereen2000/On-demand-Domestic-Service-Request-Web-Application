using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;
using ServiceSphere.Server.QueryObjects;

namespace ServiceSphere.Server.Repositories
{
    public interface IAvailableRepo
    {
        Task<Available> GetByIdAsync(int Id); // Retrieve an Available entry by ID
        Task<Available> UpdateAsync(Available available); // Update an Available entry
        Task<Available> AddAsync(Available available); // Add a new Available
        Task<Available> DeleteAsync(int Id); // Delete an Available entry
        Task<List<Available>> QueryAvailableAsync(AvailableQueryObject query);
    }
}