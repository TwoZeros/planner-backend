using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Models
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
    }
}
