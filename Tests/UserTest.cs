using API.DTO_s.User_RolesDTO_s;
using Infrastructure;
using Infrastructure.Entities.User_Roles_Entities;
using Infrastructure.User_RolesDTO_s;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Tests
{
    public class UserTest : IClassFixture<AppTest<Program>>
    {
        private readonly HttpClient _client;
        private readonly AppTest<Program> _app;
        private readonly AppDbContext _context;

        public UserTest(AppTest<Program> app)
        {
            _app = app;
            _client = app.CreateClient();
        }


        private async Task SeedData(AppDbContext _context)
        {
            var users = new HashSet<User> {
                new User() { Id = 1, Login = "test0", Password = "password123!"},
                new User() { Id = 2, Login = "test1", Password = "password123!"}
            };

            var roles = new HashSet<Role> {
                new Role() { Id = 1, RoleName = "Admin"},
                new Role() { Id = 2, RoleName = "User"}
             };

            var usersRoles = new HashSet<User_Role>
            {
                new User_Role { Id = 1, UserId = 2, RoleId = 1},
                new User_Role { Id = 2, UserId = 1, RoleId = 2}
            };

            await _context.AddRangeAsync(users);
            await _context.AddRangeAsync(roles);
            await _context.AddRangeAsync(usersRoles);

            await _context.SaveChangesAsync();
        }

        private async Task ClearData(AppDbContext context)
        {
            context.RemoveRange(context.Users);
            context.RemoveRange(context.Roles);
            context.RemoveRange(context.User_Roles);
            await context.SaveChangesAsync();
        }

        [Fact]

        public async Task LoginUser()
        {
            using (var scope = _app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await ClearData(context);
                await SeedData(context);
            }

            var model = new LoginDTO
            {
                Login = "test0",
                Password = "password123!"
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://localhost:7155/api/User/login", jsonContent);

            Assert.True(response.IsSuccessStatusCode);
        }


        [Fact]

        public async Task RegisterUser()
        {
            using (var scope = _app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await ClearData(context);
                await SeedData(context);
            }

            var model = new RegisterDTO
            {
                Login = "user02",
                Password = "pass123!",
                ConfirmPassword = "pass123!"
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://localhost:7155/api/User/register", jsonContent);

            Assert.True(response.IsSuccessStatusCode);

        }

    }

}