using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Enums;

namespace ServiceSphere.Server.DTOs.AvailableDtos
{
    public class AvailableReturnDto
    {
        // Unique identifier for the availability entry
        public int Id { get; set; }

        // Foreign key to the associated Worker
        public int WorkerId { get; set; }

        // Enumeration representing the day of the week (e.g., Monday, Tuesday, etc.)
        public Day Day { get; set; } // enum

        // Indicates if the time slot is reserved
        public bool Reserved { get; set; }
    }
}