using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models.Interfaces;

namespace Planner.Models
{
    public class Skill : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
      

        public int GroupSkillId { get; set; }
        public GroupSkill GroupSkill { get; set; }

        public List<EmployeeSkill> EmployeeSkill { get; set; }

       
    }
}
