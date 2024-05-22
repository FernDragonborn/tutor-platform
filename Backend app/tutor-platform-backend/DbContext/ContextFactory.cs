using Microsoft.EntityFrameworkCore;

namespace TutorPlatformBackend.DbContext;

public static class ContextFactory
{
    private static IConfiguration _config = new ConfigurationManager();
    private static DbContextOptions Options;

    public static void Initialize(IConfiguration config)
    {
        _config = config;
        Options = new DbContextOptionsBuilder<TutorPlatformDbContext>()
            .UseLazyLoadingProxies()
            .UseSqlServer(_config.GetConnectionString("Default"))
            .Options;
    }

    public static TutorPlatformDbContext CreateNew()
    {
        return new TutorPlatformDbContext(Options);
    }
}
