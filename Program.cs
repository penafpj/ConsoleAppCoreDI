using System.IO;
using ConsoleConfiguration.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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

            //      The options pattern uses classes to represent groups of related settings. When configuration settings are isolated by
            //  scenario into separate classes, the app adheres to two important software engineering principles:
            //  SOLID:
            //      The Interface Segregation Principle(ISP) or Encapsulation
            //          Scenarios(classes) that depend on configuration settings depend only on the configuration settings that they use.
            //    Separation of Concerns
            //          Settings for different parts of the app aren't dependent or coupled to one another.
            services.Configure<FileManagerSettings>(configuration.GetSection("FileManager"));

            //  add services: 
            //      services.AddTransient<IMyInterface, MyConcreteImplementation>();

            services.AddSingleton<IFileManager, FileManager>();

            // add app
            services.AddTransient<App>();
        }
    }
}
