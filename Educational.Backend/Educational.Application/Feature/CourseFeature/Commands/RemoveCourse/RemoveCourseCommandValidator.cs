﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.CourseFeature.Commands.RemoveCourse
{
    internal class RemoveCourseCommandValidator : AbstractValidator<RemoveCourseCommand>
    {
        public RemoveCourseCommandValidator()
        {
            RuleFor(removeCourseCommand =>
                removeCourseCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
