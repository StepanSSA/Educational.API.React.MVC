using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.CourseFeature.Commands.UpdateCourse
{
    internal class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(updateCourseCommand =>
                updateCourseCommand.Name).NotEmpty();
            RuleFor(updateCourseCommand =>
                updateCourseCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
