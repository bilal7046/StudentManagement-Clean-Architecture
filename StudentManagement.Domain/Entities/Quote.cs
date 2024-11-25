using StudentManagement.Domain.Common;

namespace StudentManagement.Domain.Entities
{
    public class Quote : BaseAuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Description { get; set; }
        public Guid ServiceId { get; set; }
        public string FullName => FirstName + " " + LastName;
        public virtual Service Service { get; set; }
    }
}