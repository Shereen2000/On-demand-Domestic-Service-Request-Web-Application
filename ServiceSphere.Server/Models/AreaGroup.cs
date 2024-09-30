using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.Models
{
    public class AreaGroup
    {
        // Unique identifier for the AreaGroup
        public int Id { get; set; }

        // Name of the AreaGroup
        public string Name { get; set; }

        // Foreign key to the associated City
        public int CityId { get; set; }

        // Navigation property to the associated City entity
        public City City { get; set; }

        // Collection of Areas that belong to this AreaGroup
        public ICollection<Area> Areas { get; set; }  

        // Collection of WorkerAreaGroup entities related to this AreaGroup
        public ICollection<WorkerAreaGroup> WorkerAreaGroups { get; set; }

        // Collection of JobApplicationAreaGroup entities related to this AreaGroup
        public ICollection<JobApplicationAreaGroup> JobApplicationAreaGroups { get; set; }

    }
}