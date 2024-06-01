using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheHandymanOfCapeCod.Core.Configuration;
using TheHandymanOfCapeCod.Core.Contracts;
using TheHandymanOfCapeCod.Core.Services;
using TheHandymanOfCapeCod.Infrastructure.Data;
using TheHandymanOfCapeCod.Infrastructure.Data.Common;


namespace Microsoft.Extensions.DependencyInjection
{

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IMailService, MailService>();


            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<TheHandymanOfCapeCodDb>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TheHandymanOfCapeCodDb>();

            return services;
        }

        public static IServiceCollection AddApplicationMailSettings(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MailSettings>(config.GetSection("MailSettings"));

            

            return services;
        }
    }
}
