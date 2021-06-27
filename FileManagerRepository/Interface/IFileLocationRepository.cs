using FileManagerDomain.Entities;

namespace FileManagerRepository.Interfaces
{
    public interface IFileLocationRepository
    {
        void Add(FileLocation fileLocation);
        bool Exists(string location);
    }
}
