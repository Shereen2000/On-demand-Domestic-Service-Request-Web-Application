using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Enums;

namespace ServiceSphere.Server.QueryObjects
{
    public class AvailableQueryObject
    {
        public int?  WorkerId { get; set; } = null;
        // Enumeration representing the day of the week (e.g., Monday, Tuesday, etc.)
        public Day? Day { get; set; } = null;

        // Indicates if the time slot is reserved
        public bool? Reserved { get; set; } = null; 

        public int? AreaGroupId { get; set; } = null;

        public int? ServiceId { get; set; } = null;
    }
}