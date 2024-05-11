using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using The_Handyman_Of_Cape_Cod.Infrastructure.Data;
using TheHandymanOfCapeCod.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            return service;
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
                .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<TheHandymanOfCapeCodDb>();

            return services;
        }
    }
}
