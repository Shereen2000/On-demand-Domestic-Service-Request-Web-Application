using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;
using ServiceSphere.Server.QueryObjects;

namespace ServiceSphere.Server.Repositories
{
    public interface IWorkerRepo
    {
        Task<Worker> GetByIdAsync(int Id); // Retrieve a Worker by ID
        Task<Worker> UpdateAsync(Worker worker); // Update a Worker
        Task<List<Worker>> QueryAsync(WorkerQueryObject query);
        Task<Worker> AddAsync(Worker worker); // Add a new Worker
        Task<Worker> DeleteAsync(int Id); // Delete a Worker
    }
}