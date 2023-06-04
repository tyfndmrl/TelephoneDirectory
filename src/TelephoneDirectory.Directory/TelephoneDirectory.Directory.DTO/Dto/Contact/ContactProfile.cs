using AutoMapper;
using TelephoneDirectory.Directory.DTO.Dto.Transaction.RequestModels;
using TelephoneDirectory.Directory.DTO.Dto.Transaction.ResponseModels;

namespace TelephoneDirectory.Directory.DTO.Dto.Transaction
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactRequestModel, DDD.Entities.ContactEntity>();
            CreateMap<DDD.Entities.ContactEntity, ContactResponseModel>();
        }
    }
}
