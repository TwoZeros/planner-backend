using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Models
{
    public class Holidays : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int BranchCompanyId { get; set; }
        public BranchCompany BranchCompany { get; set; }
    }
}
