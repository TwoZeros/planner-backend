﻿using Planner.Data.Contract.Base;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface IWorkTimeInCheduleRepository : IBaseRepository<WorkTimeInShedule>
    {
        Task<List<WorkTimeInShedule>> GetAllWorkTimeInChedule();

        Task<WorkTimeInShedule> GetWorkTimeInCheduleInfo(int id);
    }
}