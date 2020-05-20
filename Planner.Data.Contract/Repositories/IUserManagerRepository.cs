using Planner.Data.Contract.Base;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Planner.Data.Contract.Repositories
{
    public interface IUserManagerRepository 
    {

        public int GetUserIdByLogin(string username);
    }
    
}
