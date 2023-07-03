using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.CourseFeature.Queries.GetCourse
{
    public class GetCourseQuery : IRequest<CourseDetailVm>
    {
        public Guid Id { get; set; }
    }
}
