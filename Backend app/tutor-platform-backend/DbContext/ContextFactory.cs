using Microsoft.EntityFrameworkCore;

namespace TutorPlatformBackend.DbContext;

public static class ContextFactory
{
    //TODO remove connection string to other place
    private static readonly DbContextOptions Options = new DbContextOptionsBuilder<TutorPlatformDbContext>()
        .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TutorPlatform;Persist Security Info=True;User ID=app_connection_login;Password=123456")
        .UseLazyLoadingProxies()
        .Options;
    public static TutorPlatformDbContext CreateNew()
    {
        return new TutorPlatformDbContext(Options);
    }
}
