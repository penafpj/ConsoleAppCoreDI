using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Options;

namespace ConsoleConfiguration.Services
{
    public class FileManager : IFileManager
    {
        private readonly AppSettings _appSettings;

        public FileManager(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings?.Value ?? throw new ArgumentNullException();
        }
        public bool DirectoryExists()
        {
            Console.WriteLine($"Directory: {_appSettings.TempDirectory}");

            return Directory.Exists(_appSettings.TempDirectory);
        }

        public IEnumerable<string> GetListOfFiles()
        {
            return Directory.GetFiles(_appSettings.TempDirectory);
        }
    }
}
