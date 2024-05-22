using Microsoft.EntityFrameworkCore;
using TutorPlatformBackend.Data;
using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.DbContext;
public class TutorPlatformDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public TutorPlatformDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Admin> Admins { get; set; } = null!;

    public DbSet<Tutor> Tutors { get; set; } = null!;

    public DbSet<Student> Students { get; set; } = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer((@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TutorPlatform;Persist Security Info=True;User ID=app_connection_login;Password=123456"), builder =>
        {
            builder.EnableRetryOnFailure(2, TimeSpan.FromSeconds(10), null);
        });
        base.OnConfiguring(optionsBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        base.ConfigureConventions(builder);

        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter, DateOnlyComparer>()
            .HaveColumnType("date");
    }
}
