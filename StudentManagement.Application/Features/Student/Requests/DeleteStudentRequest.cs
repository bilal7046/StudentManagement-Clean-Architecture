using MediatR;

namespace StudentManagement.Application.Features.Student.Requests
{
    public class DeleteStudentRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}