using TelephoneDirectory.Directory.DTO.Dto.Transaction.ResponseModels;

namespace TelephoneDirectory.Directory.DTO.Dto.Customer.ResponseModels
{
    public class DirectoryResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
    }
}
