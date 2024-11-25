using StudentManagement.Domain.Common;

namespace StudentManagement.Domain.Entities
{
    public class Service : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
    }
}