using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Enums;

namespace ServiceSphere.Server.Models
{
    public class Client
    {
        // Unique identifier for the client entity
        public int Id { get; set; }

        // Foreign key for the associated ApplicationUser (client's account)
        public string ApplicationUserId { get; set; }
    
        // Navigation property to the associated ApplicationUser
        public ApplicationUser ApplicationUser { get; set; }

        // Collection of bookings made by the client
        public ICollection<Booking> Bookings { get; set; }

    }
}