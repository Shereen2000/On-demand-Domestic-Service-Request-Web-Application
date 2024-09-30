using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.DTOs.TaskBookingDtos
{
    public class TaskBookingReturnDto
    {
        // Foreign key to associate this task booking with a specific booking
        public int BookingId { get; set; }

        // Navigation property to the related Booking entity
        public Booking Booking { get; set; }

        // Foreign key to associate this task booking with a specific service task
        public int TaskId { get; set; }

        // Navigation property to the related ServiceTask entity
        public ServiceTask Task { get; set; }
    }
}