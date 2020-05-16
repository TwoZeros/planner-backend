using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Models
{
    public class LackTime : IEntity
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public int LackOfEmployeeId {get;set;}
        public LackOfEmployee LackOfEmployee { get; set; }
    }
}
