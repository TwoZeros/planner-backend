using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class SkillForProjectWorkDto
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public string ProjectName { get; set; }
    }
}
