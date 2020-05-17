using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class ProjectWorkSheduleDto
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public int CountHours { get; set; }
    }
}