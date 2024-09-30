using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Controllers;
using ServiceSphere.Server.DTOs.AreaGroupDtos;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Mappers
{
    public static class AreaGroupMapper
    {
        public static AreaGroupReturnDto ToAreaGroupReturnDto(this AreaGroup areaGroup)
        {
            return new AreaGroupReturnDto()
            {
                Id = areaGroup.Id,
                Name = areaGroup.Name,
                CityId = areaGroup.CityId,
                Areas = areaGroup.Areas.Select(a => a.ToAreaReturnDto()).ToList()
            };
        }
        
    }
}