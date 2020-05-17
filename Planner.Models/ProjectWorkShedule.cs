using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Models
{
    public class ProjectWorkShedule : IEntity
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public int CountHours { get; set; }
        public List<ProjectWork> ProjectWorks { get; set; }
    }
}