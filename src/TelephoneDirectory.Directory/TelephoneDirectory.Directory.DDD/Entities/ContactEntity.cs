using TelephoneDirectory.Directory.DDD.Entities.Enums;
using TelephoneDirectory.Framework.Bases;
using TelephoneDirectory.Framework.Repository.Attributes;

namespace TelephoneDirectory.Directory.DDD.Entities
{
    [BsonCollection("Contact")]
    public class ContactEntity : AuditableEntity<Guid>
    {
        public Guid DirectoryId { get; set; }
        public ContactInformationTypeEnum Type { get; set; }
        public string Content { get; set; }
    }

}