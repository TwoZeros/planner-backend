using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract
{
    public interface ILoggerService
    {
        void LogAboutSuccess(string message);
        void LogAboutError(Exception e, string message);
    }
}
