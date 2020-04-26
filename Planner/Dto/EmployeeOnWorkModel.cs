using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Dto.Models
{
    public class EmployeeOnWorkModel
    {
        public int Id { get; set; }
        public DateTime FactStart { get; set; }
        public DateTime FactEnd { get; set; }
        public int ProjectId { get; set; }
    }
}
