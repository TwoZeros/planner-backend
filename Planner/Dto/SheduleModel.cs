using Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Dto.Models

{
    public class SheduleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContryCode { get; set; }
        public WorkHoursCount workHoursCount { get; set; }
    }
}
