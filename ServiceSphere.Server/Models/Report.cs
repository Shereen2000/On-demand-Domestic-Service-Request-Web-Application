using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string? ReporterId { get; set; }
        public ApplicationUser Reporter  { get; set; }

        public string? ReportedId {get; set;}
        public ApplicationUser Reported { get; set; }

        public string IncidentBrief {get; set;}

        public int? RecruitmentRequestId {get; set;}
        public RecruitmentRequest RecruitmentRequest {get; set;}

        public string ConclusionStatement {get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt {get; set;}
    }

    public enum ReportStatus
    {
        Created,
        InvestigationPending,
        Resolved,
    }
}