using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using ServiceSphere.Server.Enums;

namespace ServiceSphere.Server.Models
{
    public class Worker
    {
        // Unique identifier for the worker
        public int Id { get; set; }

        // Identification number for the worker, such as a national ID or similar
        public string IdentificationNumber { get; set; }

        // Foreign key to link to the ApplicationUser entity
        public string ApplicationUserId { get; set; }
    
        // Navigation property to the related ApplicationUser entity
        public ApplicationUser ApplicationUser { get; set; }

        // Number of jobs completed by the worker
        public int JobCompleted { get; set; } = 0;

        // Average rating of the worker, initialized to zero
        [Column(TypeName = "decimal(18,2)")]
        public decimal Rating { get; set; } = decimal.Zero;

        // A brief description about the worker
        public string AboutWorker { get; set; } = string.Empty;

        // Foreign key to link to the City entity
        public int CityId { get; set; }

        // Navigation property to the related City entity
        public City City { get; set; }

        // Formatted address for easier display
        public string Formatted_Address { get; set; } = string.Empty;

        // Foreign key to link to the Service entity the worker offers
        public int ServiceId { get; set; }

        // Navigation property to the related Service entity
        public Service Service { get; set; }

        // Collection of area groups the worker is associated with
        public ICollection<WorkerAreaGroup> WorkerAreaGroups { get; set; }

        // Collection of bookings associated with the worker
        public ICollection<Booking> Bookings { get; set; }

        // Collection of availability records for the worker
        public ICollection<Available> Availability { get; set; }

        // Current status of the worker (e.g., active, inactive)
        public WorkerStatus Status { get; set; }
    }
}