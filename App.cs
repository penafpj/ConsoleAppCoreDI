using System;
using ConsoleConfiguration.Services;
using Microsoft.Extensions.Logging;

namespace ConsoleConfiguration
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly IFileManager _fileManager;

        public App(ILogger<App> logger, IFileManager fileManager)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _fileManager = fileManager;
        }

        public void Run()
        {
            //  App is the real starting place for this application.

            Console.WriteLine(_fileManager.DirectoryExists().ToString());

            var fileList = _fileManager.GetListOfFiles();
            foreach (var file in fileList)
            {
                Console.WriteLine(file);
            }

            //_logger.LogWarning("hello world");

            Console.Read();
        }
    }
}
