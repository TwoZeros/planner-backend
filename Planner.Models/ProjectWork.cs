using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
        public int PreviosWorkId { get; set; }
        public int NextWorkId { get; set; }
        public Project Project { get; set; }
        public List<SkillForProjectWork> SkillForProjectWork { get; set; }
    }
}
