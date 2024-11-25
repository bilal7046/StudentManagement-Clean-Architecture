using MediatR;
using StudentManagement.Domain.Request.Student;

namespace StudentManagement.Application.Features.Student.Requests
{
    public class CreateStudentRequest : IRequest<StudentRequest>
    {
        public StudentRequest StudentRequest { get; set; }
    }
}