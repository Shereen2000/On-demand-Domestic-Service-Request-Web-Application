using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.DTOs.WorkerAreaGroupDtos
{
    public class WorkerAreaGroupCreateDto
    {
         // Foreign key to link to the Worker entity
        public int WorkerId { get; set; }

        // Foreign key to link to the AreaGroup entity
        public int AreaGroupId { get; set; }

    }
}