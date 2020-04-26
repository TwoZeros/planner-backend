﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Dto.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public int ProjectManagerId { get; set; }
        public int TotalHour { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
