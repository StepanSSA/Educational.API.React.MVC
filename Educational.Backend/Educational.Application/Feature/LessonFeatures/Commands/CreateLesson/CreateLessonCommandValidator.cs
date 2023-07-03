using Educational.Domein;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.LessonFeatures.Commands.CreateLesson
{
    internal class CreateLessonCommandValidator : AbstractValidator<CreateLessonCommand>
    {
        public CreateLessonCommandValidator()
        {
            RuleFor(createLessonCommand =>
                createLessonCommand.Name).NotEmpty();
            RuleFor(createLessonCommand =>
                createLessonCommand.CourseId).NotEmpty();
            RuleFor(createLessonCommand =>
                createLessonCommand.VideoStream).NotEmpty();
        }
    }
}
