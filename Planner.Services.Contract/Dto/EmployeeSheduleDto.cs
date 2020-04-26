using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class EmployeeSheduleDto
    {
        public int Id { get; set; }
        public string StartWith { get; set; }
        public string SheduleName { get; set; }
        public string EmployeeName { get; set; }
    }
}
