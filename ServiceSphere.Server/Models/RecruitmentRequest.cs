using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.Models
{
    public class RecruitmentRequest
    {
        public int Id { get; set; }

        public string? RecruiterUserId { get; set; }
        public ApplicationUser Recruiter { get; set; }

        public ICollection<RecruitementRequestJobSeeker> RecruitmentRequestJobSeekers { get; set; }

        public string JobDescription { get; set; }

        public DateTime CreatedOn { get; set;}

        public DateTime RecruitmentStartDate { get; set; }
        public DateTime RecruitementEndDate { get; set; }

        public int NumberOfWorkersRequired { get; set; }

        [Column(TypeName = "decimal(18,2)")] // Precision and scale specified here
        public decimal HourlyWage {get;set;}
        public int DayHours {get; set;}

        public RecruitmentRequestStatus Status {get; set;}

        public double JobLatitude {get; set;}
        public double JobLongitude {get; set;}

        public Province Province {get; set;}

        public ICollection<Report> Reports {get; set;}
        public ICollection<Review> Reviews {get; set;}
    }

    public enum RecruitmentRequestStatus
    {
        RequestOpen,
        RequestCanceled,
        RequestClosed,
        JobInProgress,
        JobCompleted,
    }

    public enum Province 
    {
        Gauteng, 
        Limpopo,
        NothernCape,
        KZN,
        EasternCape,
        WesternCape,
        Mpumalanga,
        NorthWest,
        FreeState
    }
}