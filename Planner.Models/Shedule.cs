using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Models
{
    public class Shedule : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContryCode { get; set; }
        public List<WorkTimeInShedule> WorkTimeInShedules{ get; set; }
        public List<EmployeeShedule> EmployeeShedules { get; set; }
    }
}
