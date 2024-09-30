using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.DTOs.AreaDtos;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.DTOs.AreaGroupDtos
{
    public class AreaGroupReturnDto
    {
         // Unique identifier for the AreaGroup
        public int Id { get; set; }

        // Name of the AreaGroup
        public string Name { get; set; }

        // Foreign key to the associated City
        public int CityId { get; set; }

        // Collection of Areas that belong to this AreaGroup
        public ICollection<AreaReturnDto> Areas { get; set; }  

    }
}