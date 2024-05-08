using API.DTO_s.User_RolesDTO_s;
using Infrastructure.Entities.User_Roles_Entities;
using Infrastructure.JwtHelpers;
using Infrastructure.Migrations;
using Infrastructure.Services.Interfaces;
using Infrastructure.User_RolesDTO_s;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Implementations
{
    public class UserAccountService : IUserAccount
    {
        private readonly AppDbContext _appDbContext;
        private readonly IOptions<JwtSection> jwt;

        public UserAccountService(AppDbContext appDbContext, IOptions<JwtSection> options)
        {
            _appDbContext = appDbContext;
            jwt = options;
        }

        public Task CreateAsync(RegisterDTO register)
        {
            throw new NotImplementedException();
        }

        public Task LoginAsync(LoginDTO login)
        {
            throw new NotImplementedException();
        }


        private string GenerateToken(User user, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Value.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Login),
                new Claim(ClaimTypes.Role,role!)
            };

            var token = new JwtSecurityToken(issuer: jwt.Value.Issuer,audience: jwt.Value.Audience,
                claims: userClaims, expires: DateTime.Now.AddMinutes(2), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static string GenerateRefreshToken() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        private async Task<User_Role> FindUserRole(int id) =>
            await _appDbContext.User_Roles.FirstOrDefaultAsync(x => x.UserId == id);
        private async Task<Role> FindSystemRole(int id) =>
            await _appDbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);

        private async Task<User> FindUserByEmail(string login) =>
            await _appDbContext.Users.FirstOrDefaultAsync(x => x.Login.ToLower() == login.ToLower());
    }
}
