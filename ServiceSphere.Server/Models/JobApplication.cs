using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Enums;

namespace ServiceSphere.Server.Models
{
    public class JobApplication
    {

        // Unique identifier for the job application
        public int Id { get; set; }

        //Application CreatedOn
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        // Applicant's full name
        public string FullName { get; set; } = string.Empty;

        // Applicant's surname
        public string Surname { get; set; } = string.Empty;

        // Applicant's contact number
        public string ContactNumber { get; set; } = string.Empty;

        // Unique identification number for the applicant
        public string IdentificationNumber { get; set; } = string.Empty;

        // Applicant's gender
        public Gender Gender { get; set; }

        // Applicant's nationality
        public Nationality Nationality { get; set; }

        // Foreign key linking to the City associated with the application
        public int CityId { get; set; }
    
        // Navigation property to the related City
        public City City { get; set; }

        // Formatted address of the applicant
        public string Formatted_Address { get; set; } = string.Empty;

        // Collection of area groups associated with the job application
        public ICollection<JobApplicationAreaGroup> JobApplicationAreaGroups { get; set; }

        // Foreign key linking to the Service for which the application is made
        public int ServiceId { get; set; }
    
        // Navigation property to the related Service
        public Service Service { get; set; }

        // Foreign key linking to the ApplicationUser associated with the application
        public string ApplicationUserId { get; set; }
    
        // Navigation property to the related ApplicationUser
        public ApplicationUser ApplicationUser { get; set; }

        // Collection of work experiences provided in the application
        public ICollection<Experience> Experiences { get; set; }

        // Status of the application (e.g., submitted, reviewed, accepted, rejected)
        public ApplicationStatus Status { get; set; } // enum
        
    }
}