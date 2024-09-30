using Microsoft.AspNetCore.Mvc;
using ServiceSphere.Server.DTOs.CityDtos;
using ServiceSphere.Server.Mappers;
using ServiceSphere.Server.Models;
using ServiceSphere.Server.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSphere.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityRepo _cityRepo;

        public CityController(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        // GET: api/city
        [HttpGet]
        public async Task<ActionResult<List<City>>> GetAllCities()
        {
            var cities = await _cityRepo.GetAllAsync();
            return Ok(cities.Select(c => c.ToCityReturnDto()));
        }

        // GET: api/city/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCityById(int id)
        {
            var city = await _cityRepo.GetByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }


            return Ok(city.ToCityReturnDto());
        }

        // POST: api/city
        [HttpPost]
        public async Task<ActionResult<City>> AddCity([FromBody] CityCreateDto cityCreateDto)
        {
            if (cityCreateDto == null)
            {
                return BadRequest("City cannot be null.");
            }

            var city = new City()
            {
                Name = cityCreateDto.Name,
                
            };

            var addedCity = await _cityRepo.AddAsync(city);
            return CreatedAtAction(nameof(GetCityById), new { id = addedCity.Id }, addedCity);
        }

        // PUT: api/city/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<City>> UpdateCity(int id, [FromBody] City city)
        {
            if (id != city.Id)
            {
                return BadRequest("City ID mismatch.");
            }

            try
            {
                var updatedCity = await _cityRepo.UpdateAsync(city);
                return Ok(updatedCity);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/city/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<City>> DeleteCity(int id)
        {
            var deletedCity = await _cityRepo.DeleteAsync(id);
            if (deletedCity == null)
            {
                return NotFound();
            }
            return Ok(deletedCity);
        }
    }
}
