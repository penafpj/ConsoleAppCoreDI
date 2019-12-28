using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Options;

namespace ConsoleConfiguration.Services
{
    public class FileManager : IFileManager
    {
        private readonly FileManagerSettings _fileManagerSettings;

        public FileManager(IOptions<FileManagerSettings> fileManagerSettings)
        {
            _fileManagerSettings = fileManagerSettings?.Value ?? throw new ArgumentNullException();
        }
        public bool DirectoryExists()
        {
            Console.WriteLine($"Directory: {_fileManagerSettings.TempDirectory}");

            return Directory.Exists(_fileManagerSettings.TempDirectory);
        }

        public IEnumerable<string> GetListOfFiles()
        {
            return Directory.GetFiles(_fileManagerSettings.TempDirectory);
        }
    }
}
