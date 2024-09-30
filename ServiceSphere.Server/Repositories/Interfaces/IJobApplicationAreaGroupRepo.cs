using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;


namespace ServiceSphere.Server.Repositories
{
    public interface IJobApplicationAreaGroupRepo
    {
        Task<JobApplicationAreaGroup> GetByIdAsync(int jobApplicationId, int areaGroupId); // Get specific JobApplicationAreaGroup by IDs
        Task<JobApplicationAreaGroup> AddAsync(JobApplicationAreaGroup areaGroup); // Add a new JobApplicationAreaGroup
        Task<JobApplicationAreaGroup> DeleteAsync(int jobApplicationId, int areaGroupId); // Delete a JobApplicationAreaGroup
    }
}