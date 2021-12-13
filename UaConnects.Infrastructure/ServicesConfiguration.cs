using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UaConnects.Domain.Repository.Interfaces;
using UaConnects.Infrastructure.DataAccess;
using UaConnects.Infrastructure.Repositories;

namespace UaConnects.Infrastructure
{
    public static class ServicesConfiguration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            var connectionString = configuration.GetConnectionString("UaConnects");

            if (!string.IsNullOrEmpty(connectionString))
            {
                services.AddDbContext<UaConnectsContext>(options =>
                    options.UseSqlServer(connectionString));
            }
        }
    }
}
