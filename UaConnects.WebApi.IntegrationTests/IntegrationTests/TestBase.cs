using FakeItEasy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace UaConnects.WebApi.IntegrationTests.IntegrationTests
{
    public class TestBase
    {
        protected readonly IServiceProvider ServiceProvider;

        protected TestBase()
        {
            var serviceCollection = SetupDependencies();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private ServiceCollection SetupDependencies()
        {
            var configuration = A.Fake<IConfiguration>();


            var startup = new StartupOverride(configuration);
            var serviceCollection = new ServiceCollection();
            startup.ConfigureServices(serviceCollection);

            return serviceCollection;
        }
    }
}
