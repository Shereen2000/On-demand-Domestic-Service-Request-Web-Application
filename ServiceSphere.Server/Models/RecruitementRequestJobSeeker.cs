using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.Models
{
    public class RecruitementRequestJobSeeker
    {
        public int RecruitmentRequestId { get; set; }
        public RecruitmentRequest RecruitmentRequest { get; set; }

        public string JobSeekerUserId  { get; set; }
        public ApplicationUser JobSeeker { get; set; }

        public RequestStatus Status { get; set; }
  
    }

     public enum RequestStatus
    {
        Pending,
        Accepted,
        Rejected
    }
}