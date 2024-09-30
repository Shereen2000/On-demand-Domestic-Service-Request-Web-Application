using Microsoft.EntityFrameworkCore;
using ServiceSphere.Server.Data;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Repositories
{
    public class JobApplicationRepo : IJobApplicationRepo
    {
        private readonly ApplicationDbContext _context;

        public JobApplicationRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieves a JobApplication by its ID, including related properties
        public async Task<JobApplication> GetByIdAsync(int Id)
        {
            return await _context.JobApplications
                .Include(j => j.ApplicationUser) // Include related ApplicationUser
                .Include(j => j.Experiences) // Include related Experiences
                .Include(j => j.Service) // Include related Service
                .Include(j => j.JobApplicationAreaGroups) // Include related JobApplicationAreaGroups
                .AsNoTracking() // Improve performance for read-only operations
                .FirstOrDefaultAsync(j => j.Id == Id);
        }

        // Updates an existing JobApplication and returns the updated JobApplication
        public async Task<JobApplication> UpdateAsync(JobApplication jobApplication)
        {
            var existingJobApplication = await _context.JobApplications.FirstOrDefaultAsync(j => j.Id == jobApplication.Id);

            if (existingJobApplication == null)
            {
                return null; // JobApplication not found
            }

            // Update properties of the existing JobApplication
            existingJobApplication.FullName = jobApplication.FullName;
            existingJobApplication.Surname = jobApplication.Surname;
            existingJobApplication.ContactNumber = jobApplication.ContactNumber;
            existingJobApplication.IdentificationNumber = jobApplication.IdentificationNumber;
            existingJobApplication.Gender = jobApplication.Gender;
            existingJobApplication.Nationality = jobApplication.Nationality;
            existingJobApplication.CityId = jobApplication.CityId;
            existingJobApplication.Formatted_Address = jobApplication.Formatted_Address;
            existingJobApplication.ServiceId = jobApplication.ServiceId;
            existingJobApplication.Status = jobApplication.Status;
            existingJobApplication.CreatedOn = jobApplication.CreatedOn; // Update CreatedOn as well

            await _context.SaveChangesAsync();

            return existingJobApplication;
        }

        // Deletes a JobApplication by its ID and returns the deleted JobApplication
        public async Task<JobApplication> DeleteAsync(int Id)
        {
            var jobApplication = await _context.JobApplications.FirstOrDefaultAsync(j => j.Id == Id);

            if (jobApplication == null)
            {
                return null; // JobApplication not found
            }

            _context.JobApplications.Remove(jobApplication);
            await _context.SaveChangesAsync();

            return jobApplication; // Return the deleted JobApplication
        }

        public Task<JobApplication> AddAsync(JobApplication application)
        {
            throw new NotImplementedException();
        }
    }
}
