using System.ComponentModel.DataAnnotations.Schema;
using TelephoneDirectory.Framework.Bases.Interfaces;

namespace TelephoneDirectory.Framework.Bases
{
    public abstract class AuditableEntity<TKey> : Entity<TKey>, IAuditableEntity where TKey : struct
    {
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModificationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
