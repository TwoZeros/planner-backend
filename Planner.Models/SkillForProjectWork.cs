using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Models
{
    public class SkillForProjectWork : IEntity
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public int ProjectWorkId { get; set; }
        public Skill Skill { get; set; }
        public ProjectWork ProjectWork { get; set; }
    }
}
