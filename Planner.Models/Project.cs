using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Models
{
    public class Project : IEntity
    {
        public int Id { get; set; }
        public int ProjectManagerId { get; set; }
        public int TotalHour { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Employee ProjectManager { get; set; }
        public List<ProjectWork> ProjectWorks { get; set; }
        public List<EmployeeOnWork> EmployeeOnWorks { get; set; }

    }
}
