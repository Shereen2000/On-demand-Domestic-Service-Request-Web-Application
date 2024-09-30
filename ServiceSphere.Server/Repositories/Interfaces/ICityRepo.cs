using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Repositories
{
    public interface ICityRepo
    {
        Task<City> GetByIdAsync(int Id); // Retrieve a City by ID
        Task<City> UpdateAsync(City city); // Update a City
        Task<List<City>> GetAllAsync();
        Task<City> AddAsync(City city); // Add a new City
        Task<City> DeleteAsync(int Id); // Delete a City
    }
}