using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using TutorPlatformBackend.Identity;

namespace TutorPlatformBackend
{
    public sealed class Configure
    {
        internal static void AddUkrainianLanguageSupport()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            Console.InputEncoding = Encoding.GetEncoding(1251);
        }

        internal static void AddController<TContext>(WebApplicationBuilder builder, string ConnectionStringName) where TContext : Microsoft.EntityFrameworkCore.DbContext
        {
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<TContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString(ConnectionStringName)));
        }

        internal static void AddIfDevelopmentSuppressModelStateInvalidFilter(WebApplicationBuilder builder)
        {
            //Uncomment for api models problems
            //https://mirsaeedi.medium.com/asp-net-core-customize-validation-error-message-9022c12d3d7d
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.Configure<ApiBehaviorOptions>(apiBehaviorOptions =>
                {
                    apiBehaviorOptions.SuppressModelStateInvalidFilter = true;
                });
            }
        }

        internal static void AddCompression(WebApplicationBuilder builder, CompressionLevel compressionLevel)
        {
            builder.Services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });

            builder.Services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = compressionLevel;
            });
        }

        internal static void AddSwagger(WebApplicationBuilder builder)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "An ASP.NET Core Web API for managing ToDo items",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });

                //using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        internal static void AddAuthenticationAndAuthorisation(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        builder.Configuration["JwtSettings:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(IdentityData.AdminPolicyName, p =>
                    p.RequireClaim(IdentityData.AdminClaimName, "true"));
                options.AddPolicy(IdentityData.TutorPolicyName, p =>
                    p.RequireClaim(IdentityData.TutorClaimName, "true"));
                options.AddPolicy(IdentityData.StudentPolicyName, p =>
                    p.RequireClaim(IdentityData.StudentClaimName, "true"));
            });
        }
    }
}
