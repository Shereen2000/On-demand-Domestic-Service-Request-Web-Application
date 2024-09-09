using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Repositories
{
    public interface IRecruitmentRequestJobSeekerRepository
    {
        Task<RecruitementRequestJobSeeker> GetByIdAsync(string JobSeekerId, int RecruitmentRequestId);
        Task<RecruitementRequestJobSeeker> GetByJobSeekerAsync(string jobSeekerId);
        Task<RecruitementRequestJobSeeker> GetByRecruitmentRequestAsync(int recruitmentRequestId);

        Task<RecruitementRequestJobSeeker> AddAsync(RecruitementRequestJobSeeker recruitementRequestJobSeeker);

        Task<RecruitementRequestJobSeeker> DeleteAsync(string JobSeekerId, int RecruitmentRequestId);
        Task<RecruitementRequestJobSeeker> UpdateStatus(RequestStatus status);

    }
}