using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string ProjectManagerName { get; set; }
        public int TotalHour { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
