using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using ServiceSphere.Server.Enums;

namespace ServiceSphere.Server.Models
{
    public class Booking
    {
        public int Id { get; set; }

        // Date when the work is scheduled
        public DateOnly WorkDate { get; set; }

        // Time when the worker should clock in
        public TimeOnly ClockInTime { get; set; }

        // Instructions for the worker regarding the booking
        public string Instructions { get; set; }

        // Foreign key to the Service associated with this booking
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        // Collection of tasks booked for this booking
        public ICollection<TaskBooking> TasksBooked { get; set; }

        // Total hours booked, can represent fractional hours (e.g., 1.5 for 1 hour and 30 minutes)
        [Column(TypeName = "decimal(18,2)")]
        public decimal BookingHours { get; set; }

        // Total cost for this booking, represented as a decimal for currency (e.g., 49.99)
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCost { get; set; }

        // Status of the booking represented as an enum
        public BookingStatus Status { get; set; }

        // Foreign key to the City where the booking is located
        public int CityId { get; set; }
        public City City { get; set; }

        // Foreign key to the Area where the booking is located
        public int AreaId { get; set; }
        public Area Area { get; set; }

        // Formatted address for the booking
        public string Formatted_Address { get; set; } = string.Empty;

        // Foreign key to the Client who made the booking
        public int ClientId { get; set; }
        public Client Client { get; set; }

        // Foreign key to the Worker assigned to this booking
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        // Review associated with the booking
        public Review Review { get; set; }

        // Indicates whether insurance is required for this booking
        public bool RequireInsurance { get; set; } = true;
    }

}