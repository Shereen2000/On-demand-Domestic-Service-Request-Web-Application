using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.Models
{
    public class City
    {
        // Unique identifier for the city
        public int Id { get; set; }

        // Name of the city
        public string Name { get; set; } = string.Empty;

        // Collection of area groups associated with this city
        public ICollection<AreaGroup> AreaGroups { get; set; }

        // Collection of bookings made in this city
        public ICollection<Booking> Bookings { get; set; }

        // Collection of job applications submitted in this city
        public ICollection<JobApplication> JobApplications { get; set; }

        // Collection of workers associated with this city
        public ICollection<Worker> Workers { get; set; }
        
    }
}