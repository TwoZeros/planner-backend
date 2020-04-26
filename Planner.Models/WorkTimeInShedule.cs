using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Models
{
    public class WorkTimeInShedule : IEntity
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Mounth { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int SheduleId { get; set; }
        public Shedule Shedule { get; set; }

    }
}
