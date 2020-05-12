using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Planner.Models; 
using Planner.Data;
using Planner.Services;
using Planner.Common;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using Microsoft.AspNetCore.Authorization;

namespace todo.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly Planner.Services.Contract.IAuthorizationService _authorization;
        public AccountController(Planner.Services.Contract.IAuthorizationService auth)
        {
            _authorization = auth;
        }

      
        [HttpPost("/token")]
        public IActionResult Token(string username, string password)
        {
            var token =_authorization.GetToken(username, password);
           
            if (token == null)
                return BadRequest(new { errorText = "Invalid username or password." });
           
            return Json(token);
                 
        }

        [Authorize]
        [HttpGet("/getLogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }


    }
}