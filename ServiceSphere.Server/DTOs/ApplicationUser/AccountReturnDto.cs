using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.DTOs
{
    public class AccountReturnDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsWorker { get; set; }
        public string Token { get; set; }
        public string Role {get; set;} = "";
    }
}