using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class ClientsByDayDto
    {
        public List<int> Count { get; set; }
        public List<string> Date { get; set; }
    }
}
