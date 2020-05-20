using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers;
namespace Planner.Services
{
    class UserManagerService : IUserManagerService
    {
        public IUserManagerRepository _repo;

        public UserManagerService(IUserManagerRepository repo)
        {

            _repo = repo;

        }

        public int GetUserIdByLogin(string login)
        {
            return _repo.GetUserIdByLogin(login);
        }
    }
}
