using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.Server.Data;
using ServiceSphere.Server.Models;


namespace ServiceSphere.Server.Repositories
{
    public class AreaGroupRepo : IAreaGroupRepo
    {
       
        private readonly ApplicationDbContext _context;
        public AreaGroupRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AreaGroup> AddAsync(AreaGroup areaGroup)
        {
            if (areaGroup == null)
            {
                return null;
            }

            await _context.AreaGroups.AddAsync(areaGroup);

            await _context.SaveChangesAsync();

            return areaGroup;
        }

        public async Task<AreaGroup> DeleteAsync(int Id)
        {
            var areaGroup = await _context.AreaGroups.FirstOrDefaultAsync(ag => ag.Id == Id);

            if (areaGroup == null)
            {
                return null; 
            }

            _context.AreaGroups.Remove(areaGroup);

            await _context.SaveChangesAsync();

            return areaGroup; 
        }

        public async Task<List<AreaGroup>> GetAllAsync()
        {
                return await _context.AreaGroups
                .Include(c => c.Areas) // Include related AreaGroups
                    .ToListAsync();
        }

        public async Task<List<AreaGroup>> GetByCityAsync(int cityId)
        {
              return await _context.AreaGroups
                .Where(ag => ag.CityId == cityId)
                .Include(ag => ag.Areas) 
                .ToListAsync();
        }

        public async Task<AreaGroup> GetByIdAsync(int Id)
        {
            return await _context.AreaGroups
                .Include(ag => ag.Areas) 
                .AsNoTracking()
                .FirstOrDefaultAsync(ag => ag.Id == Id);
        }

    
        public async Task<AreaGroup> UpdateAsync(AreaGroup areaGroup)
        {
            var existingAreaGroup = await _context.AreaGroups.FirstOrDefaultAsync(ag => ag.Id == areaGroup.Id);

            if (existingAreaGroup == null)
            {
                return null; 
            }

            _context.Entry(existingAreaGroup).CurrentValues.SetValues(areaGroup);

            await _context.SaveChangesAsync();

            return existingAreaGroup;
        }
    }
}