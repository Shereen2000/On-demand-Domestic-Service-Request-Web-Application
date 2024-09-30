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

        public DbSet<Worker> Workers { get; set; }
        public DbSet<AreaGroup> AreaGroups { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceTask> Tasks { get; set; }
        public DbSet<TaskBooking> TaskBookings { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobApplicationAreaGroup> JobApplicationAreaGroups { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Available> Availables { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<WorkerAreaGroup> WorkerAreaGroups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<WorkerAreaGroup>()
            .HasKey(wag => new { wag.WorkerId, wag.AreaGroupId }); // Composite primary key

             modelBuilder.Entity<JobApplicationAreaGroup>()
            .HasKey(jag => new { jag.JobApplicationId, jag.AreaGroupId }); // Composite key

             modelBuilder.Entity<TaskBooking>()
            .HasKey(tb => new { tb.BookingId, tb.TaskId }); // Composite key




            // ApplicationUser to Client relationship
            modelBuilder.Entity<ApplicationUser>()
            .HasOne(a => a.Client)
            .WithOne(c => c.ApplicationUser)
            .HasForeignKey<Client>(c => c.ApplicationUserId)
            .OnDelete(DeleteBehavior.Restrict);

            // ApplicationUser to Worker relationship
            modelBuilder.Entity<ApplicationUser>()
            .HasOne(a => a.Worker)
            .WithOne(w => w.ApplicationUser)
            .HasForeignKey<Worker>(w => w.ApplicationUserId)
            .OnDelete(DeleteBehavior.Restrict);

            // ApplicationUser to JobApplication relationship (one-to-one)
            modelBuilder.Entity<ApplicationUser>()
            .HasOne(a => a.JobApplication)
            .WithOne(ja => ja.ApplicationUser)
            .HasForeignKey<JobApplication>(ja => ja.ApplicationUserId)
            .OnDelete(DeleteBehavior.Restrict);

            // Client to Booking relationship
            modelBuilder.Entity<Client>()
            .HasMany(c => c.Bookings)
            .WithOne(b => b.Client)
            .HasForeignKey(b => b.ClientId)
            .OnDelete(DeleteBehavior.Restrict); // Change to Restrict if you don't want cascading deletes

             // Worker to City relationship
            modelBuilder.Entity<Worker>()
            .HasOne(w => w.City)
            .WithMany(c => c.Workers)
            .HasForeignKey(w => w.CityId)
            .OnDelete(DeleteBehavior.Restrict); // Change to Cascade if you want cascading deletes

            // Worker to WorkerAreaGroup relationship (many-to-many)
            modelBuilder.Entity<WorkerAreaGroup>()
            .HasOne(wag => wag.Worker)
            .WithMany(w => w.WorkerAreaGroups)
            .HasForeignKey(wag => wag.WorkerId)
            .OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<WorkerAreaGroup>()
            .HasOne(wag => wag.AreaGroup)
            .WithMany(ag => ag.WorkerAreaGroups) // Assuming AreaGroup has a navigation property
            .HasForeignKey(wag => wag.AreaGroupId)
            .OnDelete(DeleteBehavior.Restrict);

            // Worker to Booking relationship
            modelBuilder.Entity<Worker>()
            .HasMany(w => w.Bookings)
            .WithOne(b => b.Worker)
            .HasForeignKey(b => b.WorkerId)
            .OnDelete(DeleteBehavior.Restrict); // Change to Restrict if you want to avoid cascading deletes

             // Worker to Service relationship
            modelBuilder.Entity<Worker>()
            .HasOne(w => w.Service)
            .WithMany(s => s.Workers)
            .HasForeignKey(w => w.ServiceId)
            .OnDelete(DeleteBehavior.Restrict); // Change to Restrict if you want to avoid cascading deletes


            // Worker to Available relationship
            modelBuilder.Entity<Worker>()
            .HasMany(w => w.Availability)
            .WithOne(a => a.Worker)
            .HasForeignKey(a => a.WorkerId)
            .OnDelete(DeleteBehavior.Restrict); // Change to Restrict if you want to avoid cascading deletes

             // JobApplication to City relationship
            modelBuilder.Entity<JobApplication>()
            .HasOne(ja => ja.City)
            .WithMany(c => c.JobApplications)
            .HasForeignKey(ja => ja.CityId)
            .OnDelete(DeleteBehavior.Restrict); // Change to Restrict if you want to avoid cascading deletes
    
            // JobApplication to Service relationship
             modelBuilder.Entity<JobApplication>()
            .HasOne(ja => ja.Service)
            .WithMany(s => s.JobApplications)
            .HasForeignKey(ja => ja.ServiceId)
            .OnDelete(DeleteBehavior.Restrict); // Change to Restrict if you want to avoid cascading deletes

            // JobApplication to JobApplicationAreaGroup relationship
             modelBuilder.Entity<JobApplicationAreaGroup>()
            .HasOne(jag => jag.JobApplication)
            .WithMany(ja => ja.JobApplicationAreaGroups)
            .HasForeignKey(jag => jag.JobApplicationId)
            .OnDelete(DeleteBehavior.Restrict); // Change to Restrict if you want to avoid cascading deletes

             modelBuilder.Entity<JobApplicationAreaGroup>()
            .HasOne(jag => jag.AreaGroup)
            .WithMany(ag => ag.JobApplicationAreaGroups) // Updated to point to the collection in AreaGroup
            .HasForeignKey(jag => jag.AreaGroupId)
            .OnDelete(DeleteBehavior.Restrict); // Change to Restrict if you want to avoid cascading deletes

            // Service to JobApplication relationship
            modelBuilder.Entity<JobApplication>()
            .HasOne(ja => ja.Service)
            .WithMany(s => s.JobApplications)
            .HasForeignKey(ja => ja.ServiceId)
            .OnDelete(DeleteBehavior.Restrict); // Change to Restrict if you want to avoid cascading deletes

             // JobApplication to Experience relationship
            modelBuilder.Entity<Experience>()
            .HasOne(e => e.JobApplication)
            .WithMany(ja => ja.Experiences)
            .HasForeignKey(e => e.JobApplicationId)
            .OnDelete(DeleteBehavior.Restrict); // Change to Restrict if you want to avoid cascading deletes

             // City to AreaGroup relationship
            modelBuilder.Entity<AreaGroup>()
            .HasOne(ag => ag.City)
            .WithMany(c => c.AreaGroups)
            .HasForeignKey(ag => ag.CityId)
            .OnDelete(DeleteBehavior.Restrict); // Change to Restrict if you want to avoid cascading deletes

             // City to Booking relationship
            modelBuilder.Entity<Booking>()
            .HasOne(b => b.City)
            .WithMany(c => c.Bookings)
            .HasForeignKey(b => b.CityId)
            .OnDelete(DeleteBehavior.Restrict); // Change to Restrict if you want to avoid cascading deletes

             // AreaGroup to Area relationship
            modelBuilder.Entity<Area>()
            .HasOne(a => a.AreaGroup)
            .WithMany(ag => ag.Areas)
            .HasForeignKey(a => a.AreaGroupId)
            .OnDelete(DeleteBehavior.Restrict); // Change to Restrict if you want to avoid cascading deletes

            // Area to Booking relationship
            modelBuilder.Entity<Booking>()
            .HasOne(b => b.Area)
            .WithMany(a => a.Bookings)
            .HasForeignKey(b => b.AreaId)
            .OnDelete(DeleteBehavior.Restrict); // Change to Restrict if you want to avoid cascading deletes

            // Configure Booking to Service relationship
            modelBuilder.Entity<Booking>()
            .HasOne(b => b.Service)
            .WithMany(s => s.Booking) // Service has many bookings
            .HasForeignKey(b => b.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);

            // Configure many-to-many relationship between Booking and ServiceTask
            modelBuilder.Entity<TaskBooking>()
            .HasOne(tb => tb.Booking)
            .WithMany(b => b.TasksBooked) // Booking has many TaskBookings
            .HasForeignKey(tb => tb.BookingId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskBooking>()
            .HasOne(tb => tb.Task)
            .WithMany(st => st.TaskBookings) // ServiceTask has many TaskBookings
            .HasForeignKey(tb => tb.TaskId)
            .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-one relationship between Booking and Review
            modelBuilder.Entity<Review>()
            .HasOne(r => r.Booking)
            .WithOne(b => b.Review) // Booking has one Review
            .HasForeignKey<Review>(r => r.BookingId) // Foreign key in Review
            .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many relationship between Service and ServiceTask
            modelBuilder.Entity<Service>()
            .HasMany(s => s.Tasks)
            .WithOne(t => t.Service)
            .HasForeignKey(t => t.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);


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
