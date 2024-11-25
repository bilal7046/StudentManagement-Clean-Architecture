using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Application.Features.Student.Requests;
using StudentManagement.Domain.Request.Student;

namespace StudentManagement.Pages.Student
{
    public class DetailModel : PageModel
    {
        private readonly IMediator _mediator;
        public StudentRequest Student { get; set; }

        public DetailModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGet(Guid id)
        {
            Student = await _mediator.Send(new GetStudentByIdRequest { Id = id });
        }
    }
}