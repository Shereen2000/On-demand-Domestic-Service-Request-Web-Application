using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;


namespace ServiceSphere.Server.Repositories
{
    public interface IJobApplicationRepo
    {
        Task<JobApplication> GetByIdAsync(int Id); // Retrieve a JobApplication by ID
        Task<JobApplication> UpdateAsync(JobApplication jobApplication); // Update a JobApplication
        Task<JobApplication> AddAsync(JobApplication application); // Add a new Service
        Task<JobApplication> DeleteAsync(int Id); // Delete a JobApplication
    }
}