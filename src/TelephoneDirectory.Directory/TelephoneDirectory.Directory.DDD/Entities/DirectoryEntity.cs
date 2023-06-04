using TelephoneDirectory.Framework.Bases;
using TelephoneDirectory.Framework.Repository.Attributes;

namespace TelephoneDirectory.Directory.DDD.Entities
{
    [BsonCollection("Directory")]
    public class DirectoryEntity : AuditableEntity<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
    }

}