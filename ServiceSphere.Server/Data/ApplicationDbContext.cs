using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<RecruitmentRequest> RecruitmentRequests { get; set; }
        public DbSet<RecruitementRequestJobSeeker> RecruitementRequestJobSeekers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<PorfolioPicture> PorfolioPictures  {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             // ApplicationUser configuration
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Skills)
                .WithOne(us => us.User)
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade); // When an ApplicationUser is deleted, all associated UserSkills are deleted

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.ReviewsGiven)
                .WithOne(r => r.Reviewer)
                .HasForeignKey(r => r.ReviewerUserId)
                .OnDelete(DeleteBehavior.Restrict); // Do not delete Reviews if the Reviewer is deleted

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.ReviewsRecieved)
                .WithOne(r => r.Reviewed)
                .HasForeignKey(r => r.ReviewedUserId)
                .OnDelete(DeleteBehavior.Restrict); // Do not delete Reviews if the Reviewed user is deleted

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.JobsRequestsReceived)
                .WithOne(rj => rj.JobSeeker)
                .HasForeignKey(rj => rj.JobSeekerUserId)
                .OnDelete(DeleteBehavior.Cascade); // When an ApplicationUser is deleted, all associated RecruitmentRequestJobSeekers are deleted

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.JobRequestsCreated)
                .WithOne(rr => rr.Recruiter)
                .HasForeignKey(rr => rr.RecruiterUserId)
                .OnDelete(DeleteBehavior.Cascade); // When an ApplicationUser is deleted, all associated RecruitmentRequests are deleted

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Reports)
                .WithOne(r => r.Reporter)
                .HasForeignKey(r => r.ReporterId)
                .OnDelete(DeleteBehavior.Restrict); // Do not delete Reports if the Reporter is deleted

            modelBuilder.Entity<PorfolioPicture>()
                .HasOne(pp => pp.Portfolio)
                .WithMany(us => us.Porfolio)
                .HasForeignKey(pp => pp.SkillId)
                .OnDelete(DeleteBehavior.SetNull); // Set SkillId to null if the Skill is deleted

            modelBuilder.Entity<RecruitementRequestJobSeeker>()
                .HasKey(rj => new { rj.RecruitmentRequestId, rj.JobSeekerUserId });

            modelBuilder.Entity<RecruitementRequestJobSeeker>()
                .HasOne(rj => rj.RecruitmentRequest)
                .WithMany(rr => rr.RecruitmentRequestJobSeekers)
                .HasForeignKey(rj => rj.RecruitmentRequestId)
                .OnDelete(DeleteBehavior.Cascade); // When a RecruitmentRequest is deleted, all associated RecruitmentRequestJobSeekers are deleted

            modelBuilder.Entity<RecruitementRequestJobSeeker>()
                .HasOne(rj => rj.JobSeeker)
                .WithMany(u => u.JobsRequestsReceived)
                .HasForeignKey(rj => rj.JobSeekerUserId)
                .OnDelete(DeleteBehavior.Restrict); // Do not delete RecruitmentRequestJobSeekers if the JobSeeker is deleted

            modelBuilder.Entity<Report>()
                .HasOne(r => r.RecruitmentRequest)
                .WithMany(rr => rr.Reports)
                .HasForeignKey(r => r.RecruitmentRequestId)
                .OnDelete(DeleteBehavior.SetNull); // Set RecruitmentRequestId to null if the RecruitmentRequest is deleted

            modelBuilder.Entity<Review>()
                .HasOne(r => r.recruitmentRequest)
                .WithMany(rr => rr.Reviews)
                .HasForeignKey(r => r.RecruitmentRequestId)
                .OnDelete(DeleteBehavior.SetNull); // Set RecruitmentRequestId to null if the RecruitmentRequest is deleted

            modelBuilder.Entity<UserSkill>()
                .HasKey(us => new { us.UserId, us.SkillId });

            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.Skill)
                .WithMany(s => s.SkilledUsers)
                .HasForeignKey(us => us.SkillId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<PorfolioPicture>()
                .HasOne(pp => pp.Portfolio)
                .WithMany(us => us.Porfolio)
                .HasForeignKey(pp => new { pp.UserId, pp.SkillId })
                .HasPrincipalKey(us => new { us.UserId, us.SkillId })
                .OnDelete(DeleteBehavior.SetNull); //


             List<IdentityRole> roles = new List<IdentityRole>
            {
               new IdentityRole
               {
                Name = "Admin",
                NormalizedName = "ADMIN"
               },
               new IdentityRole
               {
                Name = "User",
                NormalizedName = "USER"
               },

            }; modelBuilder.Entity<IdentityRole>().HasData(roles);   
        }
        
    }
}