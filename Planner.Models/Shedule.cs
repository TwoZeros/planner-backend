using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Models
{
    public class Shedule : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public int Year { get; set; }

        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }
        public int Saturday { get; set; }
        public int Sunday { get; set; }
        public string ContryCode { get; set; }
        public List<WorkTimeInShedule> WorkTimeInShedules{ get; set; }
        public List<EmployeeShedule> EmployeeShedules { get; set; }
    }
}
