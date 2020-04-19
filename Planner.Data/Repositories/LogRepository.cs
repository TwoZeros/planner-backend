using Planner.Data.Base;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Planner.Data.Contract.Base;
using System.Threading.Tasks;

namespace Planner.Data.Repositories
{
    public class LogRepository : BaseRepository<Planner.Models.LogEntry>, ILogRepository
    {
        public LogRepository(PlannerDbContext context) : base(context)
        {

        }

       

    }
}
