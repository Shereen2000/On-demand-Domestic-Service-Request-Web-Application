using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.DTOs.TaskBookingDtos
{
    public class TaskBookingCreateDto
    {
        // Foreign key to associate this task booking with a specific booking
        public int BookingId { get; set; }

        // Foreign key to associate this task booking with a specific service task
        public int TaskId { get; set; }
    }
}