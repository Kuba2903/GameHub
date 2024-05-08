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

        public async Task CreateAsync(RegisterDTO register)
        {
            if(register == null)
                throw new ArgumentNullException(nameof(register));

            var user = await FindUserByLogin(register.Login);

            if(user == null)
            {
                User newUser = new User()
                {
                    Login = register.Login,
                    Password = BCrypt.Net.BCrypt.HashPassword(register.Password)
                };

                User_Role user_Role = new User_Role()
                {
                    UserId = newUser.Id,
                    RoleId = 2 //adds user role
                };

                await _appDbContext.Users.AddAsync(newUser);
                await _appDbContext.User_Roles.AddAsync(user_Role);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("User exists");
            }


        }

        public async Task LoginAsync(LoginDTO login)
        {
            if(login == null)
                throw new ArgumentNullException(nameof(login));

            var user = await FindUserByLogin(login.Login);

            if (!BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
                throw new Exception("password invalid");


            var getUserRole = await FindUserRole(user.Id);

            var getSystemRole = await FindSystemRole(getUserRole.RoleId);

            string token = GenerateToken(user,getSystemRole.RoleName);
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

        private async Task<User> FindUserByLogin(string login) =>
            await _appDbContext.Users.FirstOrDefaultAsync(x => x.Login.ToLower() == login.ToLower());
    }
}
