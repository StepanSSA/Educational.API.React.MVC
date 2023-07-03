using FluentValidation;

namespace Educational.Application.Feature.CourseFeature.Commands.CreateCourse
{
    internal class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(createCourseCommand =>
               createCourseCommand.Id).NotNull();
            RuleFor(createCourseCommand =>
                createCourseCommand.Name).NotEmpty();
            RuleFor(createCourseCommand =>
                createCourseCommand.Duration > 0);
            RuleFor(createCourseCommand =>
                createCourseCommand.Price > 0);
            RuleFor(createCourseCommand =>
                createCourseCommand.Description).NotEmpty();
            RuleFor(createCourseCommand =>
               createCourseCommand.TeacherId).NotNull();
        }
    }
}
