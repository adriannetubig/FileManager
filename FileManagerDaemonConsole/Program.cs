using System;
using System.IO;

namespace FileManagerDaemonConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ReadFilesandSubFolders("\\\\MSI\\Shared");
        }

        static void ReadAllFilesInFolder(string folder)
        {
            foreach (string file in Directory.EnumerateFiles(folder))
            {
                Console.WriteLine(file);
            }
        }

        static void ReadFilesandSubFolders(string folder)
        {
            ReadAllFilesInFolder(folder);
            foreach (string subFolder in Directory.EnumerateDirectories(folder))
            {
                ReadFilesandSubFolders(subFolder);
            }
        }
    }
}
