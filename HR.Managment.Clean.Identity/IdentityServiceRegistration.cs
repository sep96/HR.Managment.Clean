using HR.Managment.Application.Contracts.Identity;
using HR.Managment.Application.Model.Identity;
using HR.Managment.Clean.Identity.DbContext;
using HR.Managment.Clean.Identity.Models;
using HR.Managment.Clean.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Clean.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection service , IConfiguration config)
        {
            service.Configure<JwtSetting>(config.GetSection("JwtSettings"));
            service.AddDbContext<HrLeaveManagmentIdentityDbContext>(options => {
                options.UseSqlServer(config.GetConnectionString("HrDatabaseConnectionString"));
            });

            service.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<HrLeaveManagmentIdentityDbContext>()
                .AddDefaultTokenProviders();
            service.AddTransient<IAuthService, AuthService>();
            service.AddTransient<IUserService, UserService>();

            service.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true ,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = config["JwtSettings:Issuer"] ,
                    ValidAudience = config["JwtSettings:Audience"],
                    IssuerSigningKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]))
                };
            });
            return service;
        }
    }
}
