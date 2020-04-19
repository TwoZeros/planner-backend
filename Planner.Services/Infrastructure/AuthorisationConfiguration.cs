
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Planner.Common;
using Microsoft.AspNetCore.Authorization;

namespace Planner.Services.Infrastructure
{
    public class AuthorisationConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.RequireHttpsMetadata = false;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {

                           ValidateIssuer = true,

                           ValidIssuer = AuthOptions.Issuer,

                           ValidateAudience = true,

                           ValidAudience = AuthOptions.Audience,

                           ValidateLifetime = true,

                           IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),

                           ValidateIssuerSigningKey = true,
                       };
                   });
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });
        }
    }
}
