using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Dto.Models
{
    public class WorkTimeInSheduleModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool isHoliday { get; set; }
        public string HolidayName { get; set; }
        public int CountHours { get; set; }
        public int SheduleId { get; set; }
    }
}
