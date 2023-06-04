using TelephoneDirectory.Framework.Bases;
using TelephoneDirectory.Framework.Repository.Attributes;
using TelephoneDirectory.Report.DDD.Entities.Enums;

namespace TelephoneDirectory.Report.DDD.Entities
{
    [BsonCollection("Contact")]
    public class ReportEntity : AuditableEntity<Guid>
    {
        public ReportStatusEnum Status { get; set; }
    }

}