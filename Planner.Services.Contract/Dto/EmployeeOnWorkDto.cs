using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class EmployeeOnWorkDto
    {
        public int Id { get; set; }
        public DateTime FactStart { get; set; }
        public DateTime FactEnd { get; set; }
        public string ProjectName { get; set; }
        public string EmployeeName { get; set; }
    }
}
