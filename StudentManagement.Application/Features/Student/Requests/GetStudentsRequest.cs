using MediatR;
using StudentManagement.Domain.Request.Student;

namespace StudentManagement.Application.Features.Student.Requests
{
    public class GetStudentsRequest : IRequest<IEnumerable<StudentRequest>>
    {
    }
}