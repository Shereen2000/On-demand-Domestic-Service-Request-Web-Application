using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Enums;

namespace ServiceSphere.Server.DTOs.JobApplicationDtos
{
    public class JobApplicationCreateDto
    {

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

        // Formatted address of the applicant
        public string Formatted_Address { get; set; } = string.Empty;

        // Foreign key linking to the Service for which the application is made
        public int ServiceId { get; set; }

        // Foreign key linking to the ApplicationUser associated with the application
        public string ApplicationUserId { get; set; }

        // Status of the application (e.g., submitted, reviewed, accepted, rejected)
        public ApplicationStatus Status { get; set; } // enum
    }
}