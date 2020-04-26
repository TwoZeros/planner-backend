using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class ProjectWorkDto
    {
        public int Id { get; set; }
        public int Hours { get; set; }
        public string StartTime { get; set; }
        public string DeadlineTime { get; set; }
        public int ProjectId { get; set; }
        public int PreviosWorkId { get; set; }
        public int NextWorkId { get; set; }
    }
}
