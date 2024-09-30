using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.Models
{
    public class Area
    {
       // Unique identifier for the Area
        public int Id { get; set; }

        // Name of the Area
        public string Name { get; set; } = string.Empty;
        
        // Foreign key to the associated AreaGroup
        public int AreaGroupId { get; set; }

        // Navigation property to the associated AreaGroup entity
        public AreaGroup AreaGroup { get; set; }

        // Collection of bookings associated with this Area
        public ICollection<Booking> Bookings { get; set; }
    }
}