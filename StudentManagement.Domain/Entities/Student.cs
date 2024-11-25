using StudentManagement.Domain.Common;

namespace StudentManagement.Domain.Entities
{
    public class Student : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}