using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Models
{
    public class ServiceTask
    {

        // Unique identifier for the service task
        public int Id { get; set; }

        // Name of the service task
        public string Name { get; set; } = string.Empty;

        // Detailed description of the service task
        public string Description { get; set; } = string.Empty;

        // Recommended duration to complete the task, in hours
        [Column(TypeName = "decimal(18,2)")]
        public decimal RecommendedDurationInHours { get; set; }

        // Foreign key to associate this task with a specific service
        public int ServiceId { get; set; }

        // Navigation property to the related service
        public Service Service { get; set; }

        // Collection of bookings that include this service task
        public ICollection<TaskBooking> TaskBookings { get; set; }

    }
}