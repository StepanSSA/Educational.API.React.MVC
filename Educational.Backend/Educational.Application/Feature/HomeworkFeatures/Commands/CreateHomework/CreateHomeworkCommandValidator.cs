using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.HomeworkFeatures.Commands.CreateHomework
{
    internal class CreateHomeworkCommandValidator : AbstractValidator<CreateHomeworkCommand>
    {
        public CreateHomeworkCommandValidator()
        {
            RuleFor(homework => homework.LessonId).NotNull();
            RuleFor(homework => homework.UserId).NotNull();
        }
    }
}
