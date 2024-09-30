using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.Models
{
    public class WorkerAreaGroup
    {
 
        // Foreign key to link to the Worker entity
        public int WorkerId { get; set; }

        // Navigation property to the related Worker entity
        public Worker Worker { get; set; }

        // Foreign key to link to the AreaGroup entity
        public int AreaGroupId { get; set; }

        // Navigation property to the related AreaGroup entity
        public AreaGroup AreaGroup { get; set; }

    }
}