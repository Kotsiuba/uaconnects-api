using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UaConnects.Domain.Services;
using UaConnects.Domain.Services.Interfaces;

namespace UaConnects.Domain
{
    public static class ServicesConfiguration
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}
