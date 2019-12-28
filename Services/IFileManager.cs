using System.Collections.Generic;

namespace ConsoleConfiguration.Services
{
    public interface IFileManager
    {
        bool DirectoryExists();

        IEnumerable<string> GetListOfFiles();
    }
}
