﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Dto.Models
{
    public class EmployeeSheduleModel
    {
        public int Id { get; set; }
        public DateTime StartWith { get; set; }
        public int SheduleId { get; set; }
        public int EmployeeId { get; set; }
    }
}
