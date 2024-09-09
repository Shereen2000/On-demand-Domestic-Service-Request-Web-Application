using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.Models
{
    public class PorfolioPicture
    {
        public int Id { get; set; }
        
        public string? UserId { get; set; }
        public int? SkillId { get; set; }
        public UserSkill Portfolio { get; set; }

         public string FileName { get; set; } // Name of the file stored in file system
    }
}