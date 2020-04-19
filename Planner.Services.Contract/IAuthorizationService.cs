using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

using Planner.Services.Contract.Dto;
namespace Planner.Services.Contract
{
    public interface IAuthorizationService
    {
      
        public ResponceToken SetToken(ClaimsIdentity claimsIdentity);
        public ResponceToken GetToken(string username, string password);

        public ClaimsIdentity GetIdentity(string username, string password);
        public bool IsCorrectUser(ClaimsIdentity claimsIdentity);
    }
}
