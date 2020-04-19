using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models.Interfaces;

namespace Planner.Models
{
    public class StatusOrder : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}
