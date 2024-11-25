using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Application.Features.Student.Requests;
using StudentManagement.Domain.Request.Student;

namespace StudentManagement.Pages.Student
{
    public class DeleteConfirmModel : PageModel
    {
        private readonly IMediator _mediator;

        [BindProperty]
        public StudentRequest Student { get; set; }

        public DeleteConfirmModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGet(Guid id)
        {
            Student = await _mediator.Send(new GetStudentByIdRequest() { Id = id });
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _mediator.Send(new DeleteStudentRequest() { Id = Student.Id });
            return Redirect("/student/index");
        }
    }
}