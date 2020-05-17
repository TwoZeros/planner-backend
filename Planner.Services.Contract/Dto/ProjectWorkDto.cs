
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class ProjectWorkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public string StartTime { get; set; }
        public string DeadlineTime { get; set; }
        public string ProjectName { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectWorkSheduleId { get; set; }

    }
}