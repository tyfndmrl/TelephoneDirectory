using TelephoneDirectory.Directory.DDD.Entities.Enums;

namespace TelephoneDirectory.Directory.DTO.Dto.Transaction.ResponseModels
{
    public class ContactResponseModel
    {
        public Guid Id { get; set; }
        public Guid DirectoryId { get; set; }
        public ContactInformationTypeEnum Type { get; set; }
        public string Content { get; set; }
    }
}
