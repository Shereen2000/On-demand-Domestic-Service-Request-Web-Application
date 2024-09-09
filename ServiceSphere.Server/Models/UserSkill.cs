using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.Models
{
    public class UserSkill
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }

        public ICollection<PorfolioPicture> Porfolio { get; set; }

        public ProficiecyLevel ProficiecyLevel { get; set; }
    }

    public enum ProficiecyLevel
    {
        Begginer,
        Intermidiate,
        Advanced,

    }
}