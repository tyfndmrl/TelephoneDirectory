using AutoMapper;
using TelephoneDirectory.Directory.DDD.Entities;
using TelephoneDirectory.Directory.Service.Services.Bases;
using TelephoneDirectory.Directory.Service.Services.Interfaces;
using TelephoneDirectory.Framework.Repository.Repositories.Interfaces;

namespace TelephoneDirectory.Directory.Service.Services
{
    public class ContactService : Service<IRepository<ContactEntity>, ContactEntity>, IContactService
    {
        public ContactService(IRepository<ContactEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
