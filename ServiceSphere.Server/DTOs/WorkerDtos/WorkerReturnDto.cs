using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Enums;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.DTOs.WorkerDtos
{
    public class WorkerReturnDto
    {
        // Unique identifier for the worker
        public int Id { get; set; }

        // Identification number for the worker, such as a national ID or similar
        public string IdentificationNumber { get; set; }

        // Foreign key to link to the ApplicationUser entity
        public string ApplicationUserId { get; set; }
    
        // Number of jobs completed by the worker
        public int JobCompleted { get; set; } = 0;

        // Average rating of the worker, initialized to zero
        public decimal Rating { get; set; } = decimal.Zero;

        // A brief description about the worker
        public string AboutWorker { get; set; } = string.Empty;

        // Foreign key to link to the City entity
        public int CityId { get; set; }

        // Formatted address for easier display
        public string Formatted_Address { get; set; } = string.Empty;

        // Foreign key to link to the Service entity the worker offers
        public int ServiceId { get; set; }

        // Collection of availability records for the worker
        public ICollection<Available> Availability { get; set; }

        // Current status of the worker (e.g., active, inactive)
        public WorkerStatus Status { get; set; }
    }
}