using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class EmployeeSkillDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int SkillId { get; set; }
        public int KnowledgeLevelId { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public string SkillName { get; set; }

        public string SkillGroupName { get; set; }
        public string KnowledgeLevelName { get; set; }
    }
}
