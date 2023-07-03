using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.PurchasedCoursesFeatures.Commands.CreatePurchasedCourses
{
    internal class CreatePurchasedCoursesCommandValidator : AbstractValidator<CreatePurchasedCoursesCommand>
    {
        public CreatePurchasedCoursesCommandValidator()
        {
            RuleFor(pCourse => pCourse.UserId).NotNull();
            RuleFor(pCourse => pCourse.purchasePrice).NotNull();
        }
    }
}
