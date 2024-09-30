using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;


namespace ServiceSphere.Server.Repositories
{
    public interface IAreaRepo
    {
        Task<Area> DeleteAsync(int Id);
        Task<Area> UpdateAsync(Area area);
        Task<Area> AddAsync(Area area);
        Task<Area> GetByIdAsync(int Id);
        Task<List<Area>> GetByCityAsync(int cityId);
        Task<List<Area>> GetByAreaGroupAsync(int areaGroupId);
    }
}