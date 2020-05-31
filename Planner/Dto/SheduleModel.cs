using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Models;

namespace Planner.Dto.Models
{
    public class SheduleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContryCode { get; set; }
        public int Year { get; set; }
        public WorkHoursCount workHoursCount { get; set; }
        public Services.Contract.Holiday[] Holidays { get; set; }
    }
}
