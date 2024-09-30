using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSphere.Server.Enums;
using ServiceSphere.Server.Models;

namespace ServiceSphere.Server.QueryObjects
{
    public class WorkerQueryObject
    {
        public int? CityId { get; set; } = null;
        public int? ServiceId { get; set; } = null;
        public WorkerStatus?  Status{ get; set; } = null;
        public int? AreaGroupId { get; set; } = null;
        public Day? DayAvailable { get; set; } = null;
        public bool? DayReserved { get; set; } = false;
    }
    
}