using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Domain.Entities
{
    public class AuditTrail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public string TableName { get; set; }
        public Guid RecordId { get; set; }
        public string Action { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}