using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ServiceSphere.Server.Models
{
    public class ApplicationUser: IdentityUser
    {
        public bool? IsAvailableToHire { get; set; }

        public ICollection<UserSkill> Skills { get; set; }

        public string? ProfileDescription { get; set; }

        public string? ProfilePicFileName { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public Province? Province { get; set; }

        public ICollection<Review> ReviewsGiven { get; set; }
        public ICollection<Review> ReviewsRecieved { get; set; }

        public ICollection<RecruitementRequestJobSeeker> JobsRequestsReceived { get; set; }
        public ICollection<RecruitmentRequest> JobRequestsCreated { get; set; }

        public ICollection<Report> Reports { get; set; }
        
    }
}