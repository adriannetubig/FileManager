using CSharpFunctionalExtensions;

namespace FileManagerDomain.Entities
{
    public class FileLocation: Entity
    {
        public string Location { get; private set; }

        protected FileLocation()
        {
        }

        private FileLocation(string location)
        {
            Location = location;
        }

        public static Result<FileLocation> Create(string location)
        {
            if (string.IsNullOrEmpty(location))
                return Result.Failure<FileLocation>("Location Required");

            return Result.Success(new FileLocation(location));
        }
    }
}
