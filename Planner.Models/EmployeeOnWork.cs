using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Models
{
    public class EmployeeOnWork : IEntity
    {
        public int Id { get; set; }
        public DateTime FactStart { get; set; }
        public DateTime FactEnd { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public Project Project { get; set; }
        public Employee Employee { get; set; }
    }
}
