using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.DTOs.AreaDtos
{
    public class AreaReturnDto
    {
         // Unique identifier for the Area
        public int Id { get; set; }
        
        // Name of the Area
        public string Name { get; set; } = string.Empty;
        
        // Foreign key to the associated AreaGroup
        public int AreaGroupId { get; set; }
    }
}