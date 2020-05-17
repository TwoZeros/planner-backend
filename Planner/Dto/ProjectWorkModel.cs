using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Dto.Models
{
    public class ProjectWorkModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime DeadlineTime { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectWorkSheduleId { get; set; }
    }
}