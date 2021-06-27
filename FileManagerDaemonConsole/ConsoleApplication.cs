using FileManagerService.Interfaces;
using System;
using System.IO;

namespace FileManagerDaemonConsole
{
    public sealed class ConsoleApplication
    {
        private readonly IFileLocationService _iFileLocationService;
        private readonly string _mainFolder;
        public ConsoleApplication(IFileLocationService iFileLocationService, string mainFolder)
        {
            if (iFileLocationService == null)
                throw new ArgumentNullException("IFileLocationService Required");
            if (string.IsNullOrEmpty(mainFolder))
                throw new ArgumentNullException("MainFolder Required");

            _iFileLocationService = iFileLocationService;
            _mainFolder = mainFolder;
        }

        public void Run()
        {
            ReadFilesandSubFolders(_mainFolder);
        }

        private void ReadAllFilesInFolder(string folder)
        {
            Console.WriteLine($"Checking files in {folder}");
            foreach (string file in Directory.EnumerateFiles(folder))
            {
                Console.WriteLine($"Adding: {file}");
                var addResult = _iFileLocationService.Add(file);

                if (addResult.IsSuccess)
                {
                    Console.WriteLine($"Added: {file}");
                }
                else
                {
                    Console.WriteLine($"Failed Adding: {file}");
                    Console.WriteLine(addResult.Error);
                }
            }
        }

        private void ReadFilesandSubFolders(string folder)
        {
            ReadAllFilesInFolder(folder);
            Console.WriteLine($"Checking sub folders in {folder}");
            foreach (string subFolder in Directory.EnumerateDirectories(folder))
            {
                ReadFilesandSubFolders(subFolder);
            }
        }
    }
}
