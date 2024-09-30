using Microsoft.EntityFrameworkCore;
using ServiceSphere.Server.Data;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Repositories
{
    public class JobApplicationAreaGroupRepo : IJobApplicationAreaGroupRepo
    {
        private readonly ApplicationDbContext _context;

        public JobApplicationAreaGroupRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieve a specific JobApplicationAreaGroup by JobApplicationId and AreaGroupId
        public async Task<JobApplicationAreaGroup> GetByIdAsync(int jobApplicationId, int areaGroupId)
        {
            return await _context.JobApplicationAreaGroups
                .Include(j => j.JobApplication) // Include related JobApplication
                .Include(j => j.AreaGroup) // Include related AreaGroup
                .FirstOrDefaultAsync(j => j.JobApplicationId == jobApplicationId && j.AreaGroupId == areaGroupId);
        }

        // Query JobApplicationAreaGroups based on the provided query object

        // Add a new JobApplicationAreaGroup
        public async Task<JobApplicationAreaGroup> AddAsync(JobApplicationAreaGroup areaGroup)
        {
            await _context.JobApplicationAreaGroups.AddAsync(areaGroup);
            await _context.SaveChangesAsync();
            return areaGroup; // Return the added JobApplicationAreaGroup
        }

        // Delete a JobApplicationAreaGroup by its IDs
        public async Task<JobApplicationAreaGroup> DeleteAsync(int jobApplicationId, int areaGroupId)
        {
            var areaGroup = await _context.JobApplicationAreaGroups
                .FirstOrDefaultAsync(j => j.JobApplicationId == jobApplicationId && j.AreaGroupId == areaGroupId);

            if (areaGroup == null)
            {
                return null; // JobApplicationAreaGroup not found
            }

            _context.JobApplicationAreaGroups.Remove(areaGroup);
            await _context.SaveChangesAsync();

            return areaGroup; // Return the deleted JobApplicationAreaGroup
        }
        
    }
}
