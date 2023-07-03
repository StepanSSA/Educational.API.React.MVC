using Educational.Domein;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.LessonFeatures.Queries.GetCourseLessons
{
    public class GetCourseLessonsQuery : IRequest<IList<LessonsForCourseDetailVm>>
    {
        public Guid CourseId { get; set; }
    }
}
