using Microsoft.EntityFrameworkCore;
using ServiceSphere.Server.Data;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Repositories
{
    public class ExperienceRepo : IExperienceRepo
    {
        private readonly ApplicationDbContext _context;

        public ExperienceRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieves an Experience by its ID
        public async Task<Experience> GetByIdAsync(int Id)
        {
            return await _context.Experiences
                .AsNoTracking() // Improve performance for read-only operations
                .FirstOrDefaultAsync(e => e.Id == Id);
        }

        // Updates an existing Experience and returns the updated Experience
        public async Task<Experience> UpdateAsync(Experience experience)
        {
            var existingExperience = await _context.Experiences.FirstOrDefaultAsync(e => e.Id == experience.Id);

            if (existingExperience == null)
            {
                return null; // Experience not found
            }

            // Update properties of the existing Experience
            existingExperience.JobTitle = experience.JobTitle;
            existingExperience.EmployeeName = experience.EmployeeName;
            existingExperience.StartDate = experience.StartDate;
            existingExperience.EndDate = experience.EndDate;
            existingExperience.JobDescription = experience.JobDescription;

            await _context.SaveChangesAsync();

            return existingExperience;
        }

        // Deletes an Experience by its ID and returns the deleted Experience
        public async Task<Experience> DeleteAsync(int Id)
        {
            var experience = await _context.Experiences.FirstOrDefaultAsync(e => e.Id == Id);

            if (experience == null)
            {
                return null; // Experience not found
            }

            _context.Experiences.Remove(experience);
            await _context.SaveChangesAsync();

            return experience; // Return the deleted Experience
        }

        public Task<Experience> AddAsync(Experience experience)
        {
            throw new NotImplementedException();
        }
    }
}
