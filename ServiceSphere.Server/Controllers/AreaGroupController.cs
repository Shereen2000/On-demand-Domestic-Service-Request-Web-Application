using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceSphere.Server.DTOs.AreaGroupDtos;
using ServiceSphere.Server.Models;
using ServiceSphere.Server.Repositories;

namespace ServiceSphere.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaGroupController : ControllerBase
    {
        private readonly IAreaGroupRepo _areaGroupRepo;

        public AreaGroupController(IAreaGroupRepo areaGroupRepo)
        {
            _areaGroupRepo = areaGroupRepo;
        }

        // GET: api/areagroup
        [HttpGet]
        public async Task<ActionResult<List<AreaGroup>>> GetAllAreaGroups()
        {
            var areaGroups = await _areaGroupRepo.GetAllAsync(); // Assuming you create this method
            return Ok(areaGroups);
        }

        // GET: api/areagroup/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AreaGroup>> GetAreaGroupById(int id)
        {
            var areaGroup = await _areaGroupRepo.GetByIdAsync(id);
            if (areaGroup == null)
            {
                return NotFound();
            }
            return Ok(areaGroup);
        }

        // GET: api/areagroup/city/{cityId}
        [HttpGet("city/{cityId}")]
        public async Task<ActionResult<List<AreaGroup>>> GetAreaGroupsByCity(int cityId)
        {
            var areaGroups = await _areaGroupRepo.GetByCityAsync(cityId);
            if (areaGroups == null || !areaGroups.Any())
            {
                return NotFound("No AreaGroups found for the specified city.");
            }
            return Ok(areaGroups);
        }

        // POST: api/areagroup
        [HttpPost]
        public async Task<ActionResult<AreaGroup>> AddAreaGroup([FromBody] AreaGroupCreateDto areaGroupCreateDto)
        {
            if (areaGroupCreateDto == null)
            {
                return BadRequest("AreaGroup cannot be null.");
            }

            var areaGroup = new AreaGroup()
            {
                Name = areaGroupCreateDto.Name,
                CityId = areaGroupCreateDto.CityId,
            };

            var addedAreaGroup = await _areaGroupRepo.AddAsync(areaGroup);
            return CreatedAtAction(nameof(GetAreaGroupById), new { id = addedAreaGroup.Id }, addedAreaGroup);
        }

        // PUT: api/areagroup/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<AreaGroup>> UpdateAreaGroup(int id, [FromBody] AreaGroup areaGroup)
        {
            if (id != areaGroup.Id)
            {
                return BadRequest("AreaGroup ID mismatch.");
            }

            var updatedAreaGroup = await _areaGroupRepo.UpdateAsync(areaGroup);
            if (updatedAreaGroup == null)
            {
                return NotFound();
            }

            return Ok(updatedAreaGroup);
        }

        // DELETE: api/areagroup/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<AreaGroup>> DeleteAreaGroup(int id)
        {
            var deletedAreaGroup = await _areaGroupRepo.DeleteAsync(id);
            if (deletedAreaGroup == null)
            {
                return NotFound();
            }

            return Ok(deletedAreaGroup);
        }
    }
}
