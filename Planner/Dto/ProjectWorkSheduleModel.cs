using System;

namespace Planner.Dto
{
    public class ProjectWorkSheduleModel
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public int CountHours { get; set; }
    }
}