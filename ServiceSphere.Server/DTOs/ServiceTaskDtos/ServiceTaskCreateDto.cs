using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.DTOs.ServiceTaskDtos
{
    public class ServiceTaskCreateDto
    {

        // Name of the service task
        public string Name { get; set; } = string.Empty;

        // Detailed description of the service task
        public string Description { get; set; } = string.Empty;

        // Recommended duration to complete the task, in hours
        public decimal RecommendedDurationInHours { get; set; }

        // Foreign key to associate this task with a specific service
        public int ServiceId { get; set; }

    }
}