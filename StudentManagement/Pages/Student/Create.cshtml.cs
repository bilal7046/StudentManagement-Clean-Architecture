using Azure.Core;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Application.Features.Student.Requests;
using StudentManagement.Domain.Request.Student;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace StudentManagement.Pages.Student
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IValidator<StudentRequest> _validator;

        [BindProperty]
        public StudentRequest StudentRequest { get; set; }

        public CreateModel(IMediator mediator, IValidator<StudentRequest> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var validationResult = await _validator.ValidateAsync(StudentRequest);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return Page();
            }

            var result = await _mediator.Send(new CreateStudentRequest { StudentRequest = StudentRequest });

            if (result == null)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the student. Please try again.");
                return Page();
            }

            return Redirect("/student/index");
        }
    }
}