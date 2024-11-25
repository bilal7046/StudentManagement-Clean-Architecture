using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Application.Features.Student.Requests;
using StudentManagement.Domain.Request.Student;

namespace StudentManagement.Pages.Student
{
    public class EditModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IValidator<StudentRequest> _validator;

        [BindProperty]
        public StudentRequest Student { get; set; }

        public EditModel(IMediator mediator, IValidator<StudentRequest> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public async Task OnGet(Guid id)
        {
            Student = await _mediator.Send(new GetStudentByIdRequest() { Id = id });
        }

        public async Task<IActionResult> OnPost()
        {
            var validationResult = await _validator.ValidateAsync(Student);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return Page();
            }

            var result = await _mediator.Send(new UpdateStudentRequest() { StudentRequest = Student });

            if (result == null)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the student. Please try again.");
                return Page();
            }

            return Redirect("/student/index");
        }
    }
}