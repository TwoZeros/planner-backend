using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Models
{
    public class BranchCompany : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public List<Employee> Employees { get; set; }
    }
}
