using Identity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            services.AddDbContext<AppDataContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
