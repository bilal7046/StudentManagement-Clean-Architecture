using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Application.Features.Student.Requests;
using StudentManagement.Domain.Request.Student;

namespace StudentManagement.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;
        public IEnumerable<StudentRequest> Students { get; set; }

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGet()
        {
            Students = await _mediator.Send(new GetStudentsRequest());
        }
    }
}