using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Models
{
    public class WorkTimeInShedule : IEntity
    {
        public int Id { get; set; }
        
        public DateTime Date { get; set; }
        public bool isHoliday { get; set; }
        public string HolidayName { get; set; }
        public int CountHours { get; set; }
        public int SheduleId { get; set; }
        public Shedule Shedule { get; set; }

    }
}
