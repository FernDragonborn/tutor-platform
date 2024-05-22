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
        optionsBuilder.UseSqlServer();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        base.ConfigureConventions(builder);

        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter, DateOnlyComparer>()
            .HaveColumnType("date");
    }
}
