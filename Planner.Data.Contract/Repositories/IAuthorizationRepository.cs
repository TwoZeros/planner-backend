using Planner.Data.Contract.Base;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Planner.Data.Contract.Repositories
{
    public interface IAuthorizationRepository : IBaseRepository<User>
    {

        public User GetUserByIndentity(string username, string password);
    }
    
}
