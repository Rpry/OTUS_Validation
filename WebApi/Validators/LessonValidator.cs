using FluentValidation;
using WebApi.Models;

namespace WebApi.Validators
{
    public class LessonValidator: AbstractValidator<LessonModel>
    {
        public LessonValidator()
        {
            //RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is required");
            //RuleFor(x => x.Subject).MaximumLength(20).WithMessage("Max length is 20").When(x=> x.CourseId > 100);
            //RuleFor(x => x.CourseId).GreaterThanOrEqualTo(1);
        }
    }
}