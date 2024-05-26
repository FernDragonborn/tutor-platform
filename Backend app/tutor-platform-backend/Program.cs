using LittlePictureNetworkBackend.Interfaces;
using System.IO.Compression;
using TutorPlatformBackend.DbContext;
using TutorPlatformBackend.ImageConvertors;
using TutorPlatformBackend.Interfaces;
using TutorPlatformBackend.Services;
using TutorPlatformBackend.VirusScanners;
using static TutorPlatformBackend.Configure;

namespace TutorPlatformBackend;
public class Program
{
    public static void Main(string[] args)
    {
        AddUkrainianLanguageSupport();

        var builder = WebApplication.CreateBuilder(args);

        var config = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        ContextFactory.Initialize(config);
        JwtHandler.Initialize(config);

        builder.Services.AddScoped<IVirusScanner, WindowsEmbededVirusScanner>();
        builder.Services.AddScoped<IImageConverter, SimplmageConverter>();
        builder.Services.AddScoped<FilterService>();

        AddIfDevelopmentSuppressModelStateInvalidFilter(builder);

        AddController<TutorPlatformDbContext>(builder, "Default");

        AddCompression(builder, CompressionLevel.Optimal);

        AddSwagger(builder);

        AddAuthenticationAndAuthorisation(builder);


        var app = builder.Build();

        IfIsDevelopmentUseSwaggerElseHsts(app);

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void IfIsDevelopmentUseSwaggerElseHsts(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }
        else
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
    }
}
