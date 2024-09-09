using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.Services
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
    }
}