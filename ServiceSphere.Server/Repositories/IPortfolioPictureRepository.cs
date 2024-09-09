using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;


namespace ServiceSphere.Server.Repositories
{
    public interface IPortfolioPictureRepository
    {
        Task<PorfolioPicture> GetByIdAsync(int id);
        Task<ICollection<PorfolioPicture>> Pictures(UserSkill userSkill);
        Task<PorfolioPicture> AddAsync(PorfolioPicture picture);
        Task<PorfolioPicture> DeleteAsync(int id);
    }
}