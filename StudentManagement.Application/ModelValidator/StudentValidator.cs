using FluentValidation;
using StudentManagement.Domain.Request.Student;

namespace StudentManagement.Application.ModelValidator
{
    public class StudentValidator : AbstractValidator<StudentRequest>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is requird");
            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is requird");
            RuleFor(x => x.Address).NotEmpty().WithMessage("{PropertyName} is requird");
        }
    }
}