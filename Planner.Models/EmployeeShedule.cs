using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Models
{
    public class EmployeeShedule : IEntity
    {
        public int Id { get; set; }
        public int SheduleId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public Shedule Shedule { get; set; }
        public Employee Employee { get; set; }
    }
}