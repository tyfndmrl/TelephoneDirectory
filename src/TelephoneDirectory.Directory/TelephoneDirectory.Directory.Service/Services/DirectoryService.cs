using AutoMapper;
using TelephoneDirectory.Directory.DDD.Entities;
using TelephoneDirectory.Directory.Service.Services.Bases;
using TelephoneDirectory.Directory.Service.Services.Interfaces;
using TelephoneDirectory.Framework.Repository.Repositories.Interfaces;

namespace TelephoneDirectory.Directory.Service.Services
{
    public class DirectoryService : Service<IRepository<DirectoryEntity>, DirectoryEntity>, IDirectoryService
    {
        public DirectoryService(IRepository<DirectoryEntity> repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
