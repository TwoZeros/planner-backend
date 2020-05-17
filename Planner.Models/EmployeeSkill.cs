using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models.Interfaces;

namespace Planner.Models
{
    public class EmployeeSkill : IEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int SkillId { get; set; }
        public int KnowledgeLevelId { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public Employee Employee { get; set; }
        public Skill Skill { get; set; }
        public KnowledgeLevel KnowledgeLevel { get; set; }
    }
}