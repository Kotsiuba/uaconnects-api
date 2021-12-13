using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using UaConnects.Infrastructure.DataAccess;

namespace UaConnects.WebApi.IntegrationTests
{
    public class StartupOverride : Startup
    {
        public StartupOverride(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void ConfigureApplicationServices(IServiceCollection services)
        {
            base.ConfigureApplicationServices(services);

            services.AddDbContext<UaConnectsContext>(options => options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()));
        }
    }
}
