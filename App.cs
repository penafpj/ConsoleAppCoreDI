using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace ConsoleConfiguration
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly AppSettings _appSettings;

        public App(IOptions<AppSettings> appSettings, ILogger<App> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
        }

        public async Task Run()
        {
            Console.WriteLine();
            Console.WriteLine("Hello world!");
            Console.WriteLine();
            Console.WriteLine(_appSettings.TempDirectory);
            Console.WriteLine();

            await Task.CompletedTask;
        }
    }
}
