using MediatR;
using StudentManagement.Domain.Request.Student;

namespace StudentManagement.Application.Features.Student.Requests
{
    public class GetStudentByIdRequest : IRequest<StudentRequest>
    {
        public Guid Id { get; set; }
    }
}