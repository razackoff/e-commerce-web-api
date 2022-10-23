using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Market.Application.Interfaces;

namespace Market.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection 
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<UsersDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IUserDbContext>(provider =>
                provider.GetService<UsersDbContext>());

            return services;
        }
    }
}
