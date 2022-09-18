using Application.Services.Repositories;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("HrmsProjectConnectionString")), (ServiceLifetime.Transient));
            services.AddScoped<IProgrammingLanguageEntityRepository, ProgrammingLanguageEntityRepository>();
            services.AddScoped<ITechnologyEntityRepository, TechnologyEntityRepository>();
            services.AddScoped<IUserEntityRepository, UserEntityRepository>();
            services.AddScoped<IDeveloperEntityRepository, DeveloperEntityRepository>();
            services.AddScoped<ITokenHelper, JwtHelper>();


            return services;
        }
    }
}
