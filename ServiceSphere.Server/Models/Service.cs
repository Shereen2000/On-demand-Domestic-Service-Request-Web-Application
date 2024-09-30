using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.Models
{
    public class Service
    {
        // Unique identifier for the service
        public int Id { get; set; }

        // Name of the service offered
        public string Name { get; set; }

        // Detailed description of the service
        public string Description { get; set; }

        // Rate charged per hour for the service
        [Column(TypeName = "decimal(18,2)")]
        public decimal RatePerHour { get; set; }

        // Additional fees associated with the service
        [Column(TypeName = "decimal(18,2)")]
        public decimal ServiceFees { get; set; }

        // Cost of insurance for the service
        [Column(TypeName = "decimal(18,2)")]
        public decimal InsuranceCost { get; set; }

        // List of tasks associated with this service
        public ICollection<ServiceTask> Tasks { get; set; }

        // List of job applications related to this service
        public ICollection<JobApplication> JobApplications { get; set; }

        // List of workers who provide this service
        public ICollection<Worker> Workers { get; set; }

        // List of bookings made for this service
        public ICollection<Booking> Booking { get; set; }
    }
}