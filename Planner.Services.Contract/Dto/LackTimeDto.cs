using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class LackTimeDto
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Mounth { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int LackOfEmployeeId { get; set; }
        public string LackOfEmployeeName { get; set; }
    }
}
