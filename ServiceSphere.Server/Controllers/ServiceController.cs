using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceSphere.Server.DTOs.ServiceDtos;
using ServiceSphere.Server.Mappers;
using ServiceSphere.Server.Models;
using ServiceSphere.Server.Repositories;

namespace ServiceSphere.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepo _serviceRepo;

        public ServiceController(IServiceRepo serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }

        // GET: api/service
        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _serviceRepo.GetAllAsync();

            return Ok(services.Select(s => s.ToServiceReturnDto()));
        }

        //Get: api/service/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var service = await _serviceRepo.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service.ToServiceReturnDto());
        }

         // POST: api/service
        [HttpPost]
        public async Task<IActionResult> AddService([FromBody] ServiceCreateDto serviceCreateDto)
        {
            Service service = new Service()
            {
                Name = serviceCreateDto.Name,
                Description = serviceCreateDto.Description,
                RatePerHour = serviceCreateDto.RatePerHour,
                ServiceFees = serviceCreateDto.ServiceFees,
                InsuranceCost = serviceCreateDto.InsuranceCost,
            };
            if (service == null)
            {
                return BadRequest("Service cannot be null.");
            }

            var addedService = await _serviceRepo.AddAsync(service);

            return CreatedAtAction(nameof(GetServiceById), new { id = addedService.Id }, addedService);
        }

        // DELETE: api/service/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _serviceRepo.DeleteAsync(id);

            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

    }
}