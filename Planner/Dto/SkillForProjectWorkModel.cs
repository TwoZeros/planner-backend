using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Dto.Models
{
    public class SkillForProjectWorkModel
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public int ProjectWorkId { get; set; }
    }
}
