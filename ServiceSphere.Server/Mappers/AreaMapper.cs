using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.DTOs.AreaDtos;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Mappers
{
    public static class AreaMapper
    {
        public static AreaReturnDto ToAreaReturnDto(this Area area)
        {
            return new AreaReturnDto()
            {
                Id = area.Id,
                Name = area.Name,
                AreaGroupId = area.AreaGroupId,
            };
        }
    }
}