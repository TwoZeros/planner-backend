using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Models
{
    public class EmployeeShedule : IEntity
    {
        public int Id { get; set; }
        public DateTime StartWith { get; set; }
        public int SheduleId { get; set; }
        public int EmployeeId { get; set; }
        public Shedule Shedule { get; set; }
        public Employee Employee { get; set; }
    }
}
