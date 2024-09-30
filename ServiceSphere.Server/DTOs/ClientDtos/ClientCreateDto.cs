using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.DTOs.ClientDtos
{
    public class ClientCreateDto
    {

        // Foreign key for the associated ApplicationUser (client's account)
        public string ApplicationUserId { get; set; }

    }
}