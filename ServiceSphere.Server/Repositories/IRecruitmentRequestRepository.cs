using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.DTOs;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Repositories
{
    public interface IRecruitmentRequestRepository
    {
        Task<RecruitmentRequest> GetByIdAsync(int id);
        Task<RecruitmentRequest> DeleteAsync(int id);
        Task<RecruitmentRequest> AddAsync(RecruitmentRequest recruitmentRequest);
        Task<RecruitmentRequest> UpdateAsync(int id,RecruitmentRequestUpdateDto updateDto);
        Task<RecruitmentRequest> GetByRecruiter(int recruiterId);
        
    }
}