using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Planner.Common;
using Planner.Services.Contract;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Data;
using Planner.Models;

namespace Planner.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly PlannerDbContext _context;
        private Logger _Log;
        public LoggerService(IOptions<LoggerSettings> options, PlannerDbContext context)
        {
            _context = context;
            var date = DateTime.Now;
            var logPath = options.Value.OrderLogPath + date.ToString("yyyy.MM.dd") + ".txt";
            _Log = new LoggerConfiguration().WriteTo.File(logPath).CreateLogger();
        }

        public void LogAboutSuccess(string message)
        {
            

            LogEntry logEntry = new LogEntry { Message=message, Date=DateTime.Now,Severity = LogSeverity.Info};

            string currentDatetime = DateTime.Now.ToString();
            string successMessage = "{0} - Success.Message : {1}";

            writeLogInDb(logEntry);
            _Log.Information(string.Format(successMessage, currentDatetime, message));
        }
        public void LogAboutError(Exception e, string message="no information")
        {
            LogEntry logEntry = new LogEntry { Message = message, Date = DateTime.Now, Severity = LogSeverity.Error };
            writeLogInDb(logEntry);

            string errorMessage = "ERROR: {0} {1} - Name:{2} | Phone {3}";
            string currentDatetime = DateTime.Now.ToString();
            _Log.Error(string.Format(errorMessage, e.Message, currentDatetime, message));
        }
        public void writeLogInDb(LogEntry logEntry)
        {
            _context.Logs.Add(logEntry);
            _context.SaveChanges();
        }
    }
}
