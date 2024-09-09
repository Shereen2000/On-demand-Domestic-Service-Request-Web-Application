using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.Models
{
    public class Skill
    {
        public int Id { get; set;}
        public string Description { get; set;}     

        public ICollection<UserSkill> SkilledUsers { get; set;}
    }
}