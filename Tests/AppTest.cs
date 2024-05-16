using Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Tests
{
    public class AppTest<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(
                    x => x.ServiceType == typeof(DbContextOptions<AppDbContext>));

                services.Remove(dbContextDescriptor);

                var dbConnection = services.SingleOrDefault(
                    x => x.ServiceType == typeof(DbConnection));

                services.Remove(dbConnection);


                services.AddSingleton<DbConnection>(container =>
                 {
                     var connection = new SqlConnection("Data Source=HP;Initial Catalog=video_gamesDb;Integrated Security=True;Trust Server Certificate=True");
                     connection.Open();
                     return connection;
                 });

                services.AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<AppDbContext>((container, options) =>
                {
                    options.UseInMemoryDatabase("video_gamesDb").UseInternalServiceProvider(container);
                });
            });

            builder.UseEnvironment("Development");
        }
    }
}