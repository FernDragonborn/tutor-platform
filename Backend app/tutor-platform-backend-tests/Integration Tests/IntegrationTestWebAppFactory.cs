using Microsoft.AspNetCore.Mvc.Testing;
using TutorPlatformBackend;

namespace TutorPlatformBackend_tests.Integration_Tests;
class IntegrationTestWebAppFactory : WebApplicationFactory<Program>
{
    /*private readonly MsSqlContainer _dbContainer = new MsSqlBuilder();
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var descriptor = services
                .SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<TutorPlatformDbContext>));

            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<TutorPlatformDbContext>(options =>
            {
                options.UseSqlServer("???");
            });
        });
    }*/
}

