using FileManagerDomain.Entities;
using FileManagerRepository.Interfaces;
using System;
using System.Linq;

namespace FileManagerRepository.Repositories
{
    public sealed class FileLocationRepository: IFileLocationRepository
    {
        private readonly FileManagerContext _fileManagerContext;
        public FileLocationRepository(FileManagerContext fileManagerContext)
        {
            if (fileManagerContext == null)
                throw new ArgumentNullException("FileManagerContext Required");

            _fileManagerContext = fileManagerContext;
        }

        public void Add(FileLocation fileLocation)
        {
            _fileManagerContext
                .FileLocations
                .Add(fileLocation);

            _fileManagerContext.SaveChanges();
        }

        public bool Exists(string location)
        {
            return _fileManagerContext
                .FileLocations
                .Any(a => a.Location == location);
        }
    }
}
