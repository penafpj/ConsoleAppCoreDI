using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;

namespace ConsoleConfiguration
{
    class Program
    {
        //  Based on this article:
        //      https://keestalkstech.com/2018/04/dependency-injection-with-ioptions-in-console-apps-in-net-core-2/
        //
        public static void Main(string[] args)
        {
            // create service collection
            var services = new ServiceCollection();
            ConfigureServices(services);

            // create service provider
            var serviceProvider = services.BuildServiceProvider();

            // entry point to run the application (App)
            serviceProvider.GetService<App>().Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // configure logging
            services.AddLogging(builder => builder.AddDebug().AddConsole());

            // build config
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()                              //  allows you to override settings in production
                .Build();

            services.AddOptions();
            services.Configure<AppSettings>(configuration.GetSection("App"));

            // add services:
            // services.AddTransient<IMyRespository, MyConcreteRepository>();

            // add app
            services.AddTransient<App>();
        }
    }
}
