using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Enums;

namespace ServiceSphere.Server.DTOs.JobApplicationDtos
{
    public class JobApplicationUpdateDto
    {
        // Status of the application (e.g., submitted, reviewed, accepted, rejected)
        public ApplicationStatus Status { get; set; } // enum
    }
}