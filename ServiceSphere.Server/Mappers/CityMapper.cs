using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.DTOs.CityDtos;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Mappers
{
    public static class CityMapper
    {
        public static CityReturnDto ToCityReturnDto( this City city)
        {
            return new CityReturnDto()
            {
                Id = city.Id,
                Name = city.Name,
                AreaGroups = city.AreaGroups.Select(a => a.ToAreaGroupReturnDto()).ToList(),
            };
        }
    }
}