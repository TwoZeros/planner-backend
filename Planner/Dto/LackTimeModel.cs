using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Dto.Models
{
    public class LackTimeModel
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public int LackOfEmployeeId { get; set; }
    }
}
