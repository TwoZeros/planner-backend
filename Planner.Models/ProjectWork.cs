using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Planner.Models
{
    public class ProjectWork : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime DeadlineTime { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectWorkSheduleId { get; set; }
        public ProjectWorkShedule ProjectWorkShedule { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }
        public List<SkillForProjectWork> SkillForProjectWork { get; set; }
    }
}