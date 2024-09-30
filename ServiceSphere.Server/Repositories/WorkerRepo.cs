using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.Server.Data;
using ServiceSphere.Server.Models;
using ServiceSphere.Server.QueryObjects;

namespace ServiceSphere.Server.Repositories
{
    public class WorkerRepo : IWorkerRepo
    {
        private readonly ApplicationDbContext _context;

        public WorkerRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Worker> AddAsync(Worker worker)
        {
            if (worker == null)
            {
                return null;
            }

            // Add the worker to the context
            await _context.Workers.AddAsync(worker);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the added worker (with its generated Id)
            return worker;
        }

        public async Task<Worker> DeleteAsync(int Id)
        {
             // Find the worker by ID
            var worker = await _context.Workers
                .Include(w => w.WorkerAreaGroups) // Include related entities if needed
                .Include(w => w.Availability)
                .Include(w => w.Bookings) // Include bookings to ensure they are handled if needed
                .FirstOrDefaultAsync(w => w.Id == Id);

            if (worker == null)
            {
                // Handle the case where the worker is not found (e.g., throw an exception or return null)
                return null; // or throw new KeyNotFoundException("Worker not found.");
            }

            // Optionally, handle any related data (e.g., remove bookings, availability, etc.)
            _context.WorkerAreaGroups.RemoveRange(worker.WorkerAreaGroups);
            _context.Availables.RemoveRange(worker.Availability);
            _context.Bookings.RemoveRange(worker.Bookings);
            
            // Add logic to handle bookings if necessary

            // Remove the worker
            _context.Workers.Remove(worker);

            // Save changes to the database
            await _context.SaveChangesAsync();

            return worker; // Return the deleted worker or any other relevant information
        }

        public async Task<Worker> GetByIdAsync(int Id)
        {
             // Fetch the worker by ID, including related entities if necessary
                var worker = await _context.Workers
                    .Include(w => w.City) // Include related City entity
                    .Include(w => w.Service) // Include related Service entity
                    .Include(w => w.WorkerAreaGroups) // Include area groups
                    .Include(w => w.Availability) // Include availability records
                    .Include(w => w.Bookings) // Include bookings if needed
                    .FirstOrDefaultAsync(w => w.Id == Id); // Use FirstOrDefault to get a single worker

                return worker; // Return the found worker, or null if not found
        }

        public async Task<List<Worker>> QueryAsync(WorkerQueryObject query)
        {
             var queryable = _context.Workers
            .Include(w => w.City)
            .Include(w => w.Service)
            .Include(w => w.WorkerAreaGroups)
            .Include(w => w.Availability)
            .AsQueryable();

             // Apply filters based on the query object
            if (query.CityId.HasValue)
            {
                queryable = queryable.Where(w => w.CityId == query.CityId.Value);
            }

            if (query.ServiceId.HasValue)
            {
                queryable = queryable.Where(w => w.ServiceId == query.ServiceId.Value);
            }

            if (query.Status.HasValue)
            {
                queryable = queryable.Where(w => w.Status == query.Status.Value);
            }

            if (query.AreaGroupId.HasValue)
            {
                queryable = queryable
                .Where(w => w.WorkerAreaGroups.Any(wag => wag.AreaGroupId == query.AreaGroupId.Value));
            }

            if (query.DayAvailable.HasValue)
            {
                queryable = queryable
                    .Where(w => w.Availability.Any(a => a.Day == query.DayAvailable.Value && !a.Reserved));
            }

            return await queryable.ToListAsync();



        }

        public async Task<Worker> UpdateAsync(Worker worker)
        {
            if (worker == null)
            {
                return null;
             }

            // Check if the worker exists
            var existingWorker = await _context.Workers.FindAsync(worker.Id);
            if (existingWorker == null)
            {
                throw new KeyNotFoundException("Worker not found.");
            }

            // Update properties (if needed) - This can be handled automatically by EF Core
            _context.Entry(existingWorker).CurrentValues.SetValues(worker);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the updated worker
            return existingWorker;
        }
    }
}