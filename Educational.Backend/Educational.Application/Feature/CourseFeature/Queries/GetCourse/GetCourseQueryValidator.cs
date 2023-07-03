using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.CourseFeature.Queries.GetCourse
{
    internal class GetCourseQueryValidator : AbstractValidator<GetCourseQuery>
    {
        public GetCourseQueryValidator() 
        {
            RuleFor(course => course.Id).NotEqual(Guid.Empty);
        }
    }
}
