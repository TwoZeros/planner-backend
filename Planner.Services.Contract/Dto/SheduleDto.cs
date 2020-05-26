using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class SheduleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public int Year { get; set; }
        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }
        public int Saturday { get; set; }
        public int Sunday { get; set; }
        public string ContryCode { get; set; }
    }
}
