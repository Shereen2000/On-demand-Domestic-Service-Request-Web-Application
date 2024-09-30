using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceSphere.Server.DTOs.AreaDtos;
using ServiceSphere.Server.Models;
using ServiceSphere.Server.Repositories;

namespace ServiceSphere.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : ControllerBase
    {
        
        private readonly IAreaRepo _areaRepo;

        public AreaController(IAreaRepo areaRepo)
        {
            _areaRepo = areaRepo;
        }

         // GET: api/area/city/{cityId}
        [HttpGet("city/{cityId}")]
        public async Task<ActionResult<List<Area>>> GetAreaByCityAsync(int cityId)
        {
            var areas = await _areaRepo.GetByCityAsync(cityId); // Adjust this if you want to return all areas
            return Ok(areas);
        }

          // GET: api/area/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> GetAreaById(int id)
        {
            var area = await _areaRepo.GetByIdAsync(id);
            if (area == null)
            {
                return NotFound();
            }
            return Ok(area);
        }

        // GET: api/area/areagroup/{areaGroupId}
        [HttpGet("areagroup/{areaGroupId}")]
        public async Task<ActionResult<List<Area>>> GetAreasByAreaGroup(int areaGroupId)
        {
            var areas = await _areaRepo.GetByAreaGroupAsync(areaGroupId);
            if (areas == null || !areas.Any())
            {
                return NotFound("No areas found for the specified AreaGroup.");
            }
            return Ok(areas);
        }

        //POST: api/area
        [HttpPost]
        public async Task<ActionResult<Area>> AddArea([FromBody] AreaCreateDto areaCreateDto)
        {
            if (areaCreateDto == null)
            {
                return BadRequest("Area cannot be null.");
            }

            var area = new Area()
            {
                Name = areaCreateDto.Name,
                AreaGroupId = areaCreateDto.AreaGroupId,
                // Set other properties as needed
            };

            var addedArea = await _areaRepo.AddAsync(area);
            return CreatedAtAction(nameof(GetAreaById), new { id = addedArea.Id }, addedArea);
        }



    }
}