using Planner.Data.Contract.Base;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface ICarmaRepository : IBaseRepository<CarmaUser>
    {
        Task<CarmaUser> GetStatusByNumber(int number);
        void PutCarmaClient(CarmaUser carmaUser);
    }
}