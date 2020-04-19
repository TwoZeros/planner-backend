using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
namespace Planner.Models
{
    public class LogEntry : IEntity
    {
        public int Id { get; set; }

        public LogSeverity Severity { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }
    }

    public enum LogSeverity
    {
        Debug = 0,
        Info = 1,
        Error = 2
    }
}
