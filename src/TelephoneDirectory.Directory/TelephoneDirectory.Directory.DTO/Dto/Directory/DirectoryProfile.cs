using AutoMapper;
using TelephoneDirectory.Directory.DTO.Dto.Customer.RequestModels;
using TelephoneDirectory.Directory.DTO.Dto.Customer.ResponseModels;

namespace TelephoneDirectory.Directory.DTO.Dto.Customer
{
    public class DirectoryProfile : Profile
    {
        public DirectoryProfile()
        {
            CreateMap<DirectoryRequestModel, DDD.Entities.DirectoryEntity>();
            CreateMap<DDD.Entities.DirectoryEntity, DirectoryResponseModel>();
        }
    }
}
