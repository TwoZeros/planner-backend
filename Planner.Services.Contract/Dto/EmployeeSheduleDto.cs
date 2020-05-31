using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class EmployeeSheduleDto
    {
        public int Id { get; set; }
        public string SheduleName { get; set; }
        public string EmployeeName { get; set; }
        public int SheduleId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
    }
}