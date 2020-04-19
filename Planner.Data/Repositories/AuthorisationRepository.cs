using Planner.Data.Base;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Planner.Data.Contract.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Planner.Data.Repositories
{
    public class AuthorizationRepository : BaseRepository<Planner.Models.User>, IAuthorizationRepository
    {
        private readonly PlannerDbContext _context;
        public AuthorizationRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }
        public User GetUserByIndentity(string username, string password)
        {
            return  _context.Users.FirstOrDefault(x => x.Login == username && x.Password == password);
        }


       

    }
}
