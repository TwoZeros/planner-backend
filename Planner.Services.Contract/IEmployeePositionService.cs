using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planner.Models;
using Planner.Services.Contract.Base;
using Planner.Services.Contract.Dto;

namespace Planner.Services.Contract
{
    public interface IEmployeePositionService : IBaseServices<Position>
    {
        Task Update(Position position);
    }
}
