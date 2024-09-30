using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;


namespace ServiceSphere.Server.Repositories
{
    public interface IAreaGroupRepo
    {
        Task<AreaGroup> GetByIdAsync(int Id); // Retrieve an AreaGroup by ID
        Task<AreaGroup> UpdateAsync(AreaGroup areaGroup); // Update an AreaGroup
        Task<AreaGroup> AddAsync(AreaGroup areaGroup); // Add a new AreaGroup
        Task<List<AreaGroup>> GetAllAsync();
        Task<AreaGroup> DeleteAsync(int Id); // Delete an AreaGroup
        Task<List<AreaGroup>>  GetByCityAsync(int CityId);

    }
}