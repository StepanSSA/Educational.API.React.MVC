using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.CourseFeature.Queries.GetCourses
{
    public class GetCourseListQuery : IRequest<IList<CourseLookupDto>>
    {
        public Guid Id { get; set; }
    }
}
