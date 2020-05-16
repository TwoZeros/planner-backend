using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class WorkTimeInSheduleDto
    {
        public int Id { get; set; }
        
        [Column(TypeName = "Date")]
        public string Date { get; set; }
        public bool isHoliday { get; set; }
        public string HolidayName { get; set; }
        public int CountHours { get; set; }
        public string SheduleName { get; set; }
    }
}
