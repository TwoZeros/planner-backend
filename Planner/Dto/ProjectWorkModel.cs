using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Dto.Models
{
    public class ProjectWorkModel
    {
        public int Id { get; set; }
        public int Hours { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime DeadlineTime { get; set; }
        public int ProjectId { get; set; }
        public int PreviosWorkId { get; set; }
        public int NextWorkId { get; set; }    
    }
}
