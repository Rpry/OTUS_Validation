using FluentValidation;
using WebApi.Models;

namespace WebApi.Validators
{
    public class LessonValidator : AbstractValidator<LessonModel>
    {
        public LessonValidator()
        {
            //RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is absolutely required");
            //RuleFor(x => x.CourseId).GreaterThanOrEqualTo(1);
            //RuleFor(x => x.Subject).MaximumLength(10).WithMessage("Max length is 10").When(x=> x.CourseId > 100);
        }
    }
}