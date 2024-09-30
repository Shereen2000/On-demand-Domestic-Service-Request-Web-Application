using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.DTOs.ExperienceDtos
{
    public class ExperienceCreateDto
    {

        // Foreign key linking to the associated JobApplication
        public int JobApplicationId { get; set; }
    
        // Title of the job held by the applicant
        public string JobTitle { get; set; } = string.Empty;

        // Name of the employer or company where the experience was gained
        public string EmployeeName { get; set; } = string.Empty;

        // Start date of the job experience
        public DateOnly StartDate { get; set; }

        // End date of the job experience
        public DateOnly EndDate { get; set; }

        // Description of the job responsibilities and achievements
        public string JobDescription { get; set; } = string.Empty;
    }
}