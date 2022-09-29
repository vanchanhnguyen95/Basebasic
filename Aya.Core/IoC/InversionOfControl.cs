using Aya.Bussiness;
using Aya.Bussiness.Interface;
using Aya.Infrastructure;
using Aya.Infrastructure.Models;
using Aya.Infrastructure.UOW;
using Aya.Services;
using Aya.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aya.Core.IoC
{
    public static class InversionOfControl
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //Signleton
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<AyaDbContext>()
                    .AddDefaultTokenProviders();

            services.AddDbContext(configuration);

            //Scoped
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<ICategoryService, CategoryService>();

            //Transient

            return services;
        }

        private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AyaDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AyaDbContext")));
            return services;
        }
    }
}