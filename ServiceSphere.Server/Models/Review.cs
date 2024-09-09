using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ServiceSphere.Server.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string? ReviewerUserId { get; set; }
        public ApplicationUser Reviewer { get; set; }

        public string? ReviewedUserId { get; set; } 
        public ApplicationUser Reviewed { get; set; }

        public int Rating { get; set; }
        public string Comment { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int? RecruitmentRequestId { get; set; }
        public RecruitmentRequest recruitmentRequest { get; set; }

    }
}