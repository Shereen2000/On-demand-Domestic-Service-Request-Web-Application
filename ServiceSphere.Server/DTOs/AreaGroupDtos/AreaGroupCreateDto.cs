using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.DTOs.AreaGroupDtos
{
    public class AreaGroupCreateDto
    {
    
        // Name of the AreaGroup
        public string Name { get; set; }

        // Foreign key to the associated City
        public int CityId { get; set; }

    }
}