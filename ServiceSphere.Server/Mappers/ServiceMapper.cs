using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.DTOs.ServiceDtos;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Mappers
{
    public static class ServiceMapper
    {
        public static ServiceReturnDto ToServiceReturnDto(this Service service)
        {
            return new ServiceReturnDto
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                InsuranceCost = service.InsuranceCost,
                ServiceFees = service.ServiceFees,
                Tasks = service.Tasks,
                RatePerHour = service.RatePerHour,
            };
        }
    }
}