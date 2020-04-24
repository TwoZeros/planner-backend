using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Dto.Models
{
    public class EmployeeSkillModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int SkillId { get; set; }
        public int KnowledgeLevelId { get; set; }
        public DateTime DateOfAppointment { get; set; }
        EmployeeSkillModel()
        {
            DateOfAppointment = DateTime.UtcNow;
        }
    }
}
