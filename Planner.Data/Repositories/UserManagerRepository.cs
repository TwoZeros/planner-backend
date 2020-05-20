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
using Microsoft.AspNetCore.Mvc;

namespace Planner.Data.Repositories
{
    public class UserManagerRepository : BaseRepository<CarmaUser>, IUserManagerRepository
    {
        private readonly PlannerDbContext _context;

        public UserManagerRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetUserIdByLogin(string login)
        {
            var user = _context.Users.FirstOrDefault(f => f.Login == login);
            return user.Id;
        }
    }
}