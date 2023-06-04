using TelephoneDirectory.Directory.DDD.Entities.Enums;

namespace TelephoneDirectory.Directory.DTO.Dto.Transaction.RequestModels
{
    public class ContactRequestModel
    {
        public Guid DirectoryId { get; set; }
        public ContactInformationTypeEnum Type { get; set; }
        public string Content { get; set; }
    }
}
