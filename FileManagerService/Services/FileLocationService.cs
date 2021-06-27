using CSharpFunctionalExtensions;
using FileManagerDomain.Entities;
using FileManagerRepository.Interfaces;
using FileManagerService.Interfaces;
using System;

namespace FileManagerService.Services
{
    public sealed class FileLocationService: IFileLocationService
    {
        private IFileLocationRepository _iFileLocationRepository;

        public FileLocationService(IFileLocationRepository iFileLocationRepository)
        {
            if (iFileLocationRepository == null)
                throw new ArgumentNullException("IFileLocationRepository Required");

            _iFileLocationRepository = iFileLocationRepository;
        }

        public Result Add(string location)
        {
            var fileLocationResult = FileLocation.Create(location);
            if (fileLocationResult.IsFailure)
                return Result.Failure(fileLocationResult.Error);
            if(_iFileLocationRepository.Exists(location))
                return Result.Failure("File Location Already exists");

            _iFileLocationRepository.Add(fileLocationResult.Value);

            return Result.Success();
        }
    }
}
