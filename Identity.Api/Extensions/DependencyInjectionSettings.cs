using Identity.Application.Mapping;
using Identity.Application.Services;
using Identity.Core.Interfaces.Repositories;
using Identity.Core.Interfaces.Services;
using Identity.Core.Interfaces.UnitOfWork;
using Identity.Infrastructure.Data.Repositories;
using Identity.Infrastructure.Data.UnitOfWork;

namespace Identity.Api.Extensions
{
    public static class DependencyInjectionSettings
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(ISqlServerRepository<>), typeof(SqlServerRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddAutoMapper(x =>
            {
                x.AddProfile<AuthenticationProfiler>();
            });
        }
    }
}
