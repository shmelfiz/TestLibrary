using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AlbumsLibraryTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                 .ConfigureAppConfiguration((hostingContext, config) =>
                 {
                     var env = hostingContext.HostingEnvironment;
                     config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                             .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                                 optional: true, reloadOnChange: true);
                     config.AddEnvironmentVariables();
                 })
                 .ConfigureLogging((hostingContext, logging) =>
                 {
                     logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                 })
                .UseStartup<Startup>();
    }
}
