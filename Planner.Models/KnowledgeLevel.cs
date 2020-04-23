using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Models.Interfaces;

namespace Planner.Models
{
    public class KnowledgeLevel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
