using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.DTOs.JobApplicationAreaGroupDtos
{
    public class JobApplicationAreaGroupCreateDto
    {
        // Foreign key linking to the JobApplication associated with this area group
        public int JobApplicationId { get; set; }

        // Foreign key linking to the AreaGroup associated with this job application
        public int AreaGroupId { get; set; }

    }
}