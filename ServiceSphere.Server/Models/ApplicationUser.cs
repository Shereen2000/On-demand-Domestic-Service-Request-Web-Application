using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServiceSphere.Server.Enums;

namespace ServiceSphere.Server.Models
{
    public class ApplicationUser: IdentityUser
    {
        // Navigation property to the associated Client entity
        public Client Client { get; set; }

        // Navigation property to the associated Worker entity
        public Worker Worker { get; set; }

        // The user's first name
        public string Name { get; set; }

        // The user's surname (last name)
        public string Surname { get; set; }

        // Indicates whether the user is a worker (true) or a client (false)
        public bool IsWorker { get; set; } = false;

        // The role of the user (could be admin, user, etc.)
        public Role Role { get; set; }

        // Navigation property to the associated JobApplication entity
        public JobApplication JobApplication { get; set; }

    }
}