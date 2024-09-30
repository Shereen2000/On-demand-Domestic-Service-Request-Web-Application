using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.DTOs.JobApplicationAreaGroupDtos
{
    public class JobApplicationAreaGroupReturnDto
    {
          // Foreign key linking to the JobApplication associated with this area group
        public int JobApplicationId { get; set; }

        // Navigation property to the related JobApplication
        public JobApplication JobApplication { get; set; }

        // Foreign key linking to the AreaGroup associated with this job application
        public int AreaGroupId { get; set; }

        // Navigation property to the related AreaGroup
        public AreaGroup AreaGroup { get; set; }
    }
}