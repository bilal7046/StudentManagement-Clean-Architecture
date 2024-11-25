namespace StudentManagement.Domain.Request.Student
{
    public class StudentRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}