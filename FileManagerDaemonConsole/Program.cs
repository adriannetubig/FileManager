using FileManagerRepository;
using FileManagerRepository.Interfaces;
using FileManagerRepository.Repositories;
using FileManagerService.Interfaces;
using FileManagerService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace FileManagerDaemonConsole
{
    class Program
    {
        //Previous Implementation
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");
        //    ReadFilesandSubFolders("\\\\MSI\\Shared");
        //}

        //static void ReadAllFilesInFolder(string folder)
        //{
        //    foreach (string file in Directory.EnumerateFiles(folder))
        //    {
        //        Console.WriteLine(file);
        //    }
        //}

        //static void ReadFilesandSubFolders(string folder)
        //{
        //    ReadAllFilesInFolder(folder);
        //    foreach (string subFolder in Directory.EnumerateDirectories(folder))
        //    {
        //        ReadFilesandSubFolders(subFolder);
        //    }
        //}

        static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<ConsoleApplication>().Run();
        }
        private static IServiceCollection ConfigureServices()
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var mainFolder = configuration.GetSection("MainFolder").Get<string>();

            IServiceCollection services = new ServiceCollection();
            services.AddScoped(a => new FileManagerContext(connectionString));

            services.AddSingleton<IFileLocationRepository, FileLocationRepository>();

            services.AddSingleton<IFileLocationService, FileLocationService>();

            services.AddTransient(a => new ConsoleApplication(a.GetService<IFileLocationService>(), mainFolder));
            return services;
        }
    }
}
