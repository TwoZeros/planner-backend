using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Dto.Models
{
    public class LackTimeModel
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Mounth { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int LackOfEmployeeId { get; set; }
    }
}
