using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AlbumsLibraryTest.BLL.Tests.Helper
{
    public static class ConfigurationHelper
    {
        #region Fields

        public static IServiceCollection services;

        #endregion

        #region Installing config

        public static void Setup()
        {
            var config = GetIConfigurationRoot(AppContext.BaseDirectory);

            services = new ServiceCollection();

            services.AddScoped<IConfiguration>(factory =>
            {
                return config;
            });
            services.AddLogging();

            var startup = new Startup(config);

            startup.ConfigureServices(services);
        }

        #endregion

        #region Config root

        private static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        #endregion
    }
}
