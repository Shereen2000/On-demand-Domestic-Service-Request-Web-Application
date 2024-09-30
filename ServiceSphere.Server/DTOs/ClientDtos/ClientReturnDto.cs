using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.DTOs.ClientDtos
{
    public class ClientReturnDto
    {
         // Unique identifier for the client entity
        public int Id { get; set; }

        // Foreign key for the associated ApplicationUser (client's account)
        public string ApplicationUserId { get; set; }

        // Collection of bookings made by the client
        public ICollection<Booking> Bookings { get; set; }

    }
}