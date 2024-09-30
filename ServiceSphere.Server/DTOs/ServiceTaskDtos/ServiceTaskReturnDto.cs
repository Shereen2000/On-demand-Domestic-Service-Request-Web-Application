using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.DTOs.ServiceTaskDtos
{
    public class ServiceTaskReturnDto
    {
        
        // Unique identifier for the service task
        public int Id { get; set; }

        // Name of the service task
        public string Name { get; set; } = string.Empty;

        // Detailed description of the service task
        public string Description { get; set; } = string.Empty;

        // Recommended duration to complete the task, in hours
        public decimal RecommendedDurationInHours { get; set; }

    }
}