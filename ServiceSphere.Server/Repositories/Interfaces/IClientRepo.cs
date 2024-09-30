using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Repositories
{
    public interface IClientRepo
    {
        Task<Client> GetByIdAsync(int Id); // Retrieve a Client by ID
        Task<Client> AddAsync(Client client); // Add a new Client
        Task<Client> DeleteAsync(int Id); // Delete a Client
    }
}