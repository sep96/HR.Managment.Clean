using HR.Managment.Application.Contracts.Identity;
using HR.Managment.Application.Exceptions;
using HR.Managment.Application.Model.Identity;
using HR.Managment.Clean.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Clean.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSetting _jwtSetting;

        public AuthService(UserManager<ApplicationUser> userManger, SignInManager<ApplicationUser> signInManager, IOptions<JwtSetting> jwtSetting)
        {
            _userManger = userManger;
            _signInManager = signInManager;
            _jwtSetting = jwtSetting.Value;
        }

        public async  Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManger.FindByEmailAsync(request.Email);
            if(user is null)
                throw new NotFoundException($"User {request.Email} Not Found " , request.Email);
            var result = await _signInManager.CheckPasswordSignInAsync(user , request.Password , false);
            if (!result.Succeeded)
                throw new BadRequestException("UserName or password is Not Valid");
            var jwtSecurityToken = await GenerateToken(user);

            return new AuthResponse
            {
                ID = user.Id,
                Email = user.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName = user.UserName
            };
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaim = await _userManger.GetClaimsAsync(user);
            var role = await _userManger.GetRolesAsync(user);
            var roleClaim = role.Select(x=> new Claim(ClaimTypes.Role , x)).ToList();
            var claims = new[]
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub , user.FirstName),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti ,Guid.NewGuid().ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email , user.Email),
                new Claim("uid" , user.Id)
            }.Union(roleClaim).Union(roleClaim);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Key));
            var signingCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken (
                issuer: _jwtSetting.Issuer ,
                audience: _jwtSetting.Audience ,
                claims:claims ,
                expires : DateTime.Now.AddMinutes(_jwtSetting.DurationInMinutes),
                signingCredentials: signingCredential);
            return jwtSecurityToken;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.Firstname,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };
            var result = _userManger.CreateAsync(user, request.Password);
            if(result.IsCompletedSuccessfully)
            {
                await _userManger.AddToRoleAsync(user, "Employee");
                return new RegistrationResponse { UserID = user.Id };
            }
            else
            {
                StringBuilder str = new StringBuilder();
                //foreach(var err in result.)
                throw new BadRequestException("Falied To Create USer ");
            }
        }
    }
}
