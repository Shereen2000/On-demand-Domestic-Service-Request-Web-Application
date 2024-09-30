using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.DTOs.AreaGroupDtos;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.DTOs.CityDtos
{
    public class CityReturnDto
    {
        // Unique identifier for the city
        public int Id { get; set; }

        // Name of the city
        public string Name { get; set; } = string.Empty;

        // Collection of area groups associated with this city
        public ICollection<AreaGroupReturnDto> AreaGroups { get; set; }

    }
}