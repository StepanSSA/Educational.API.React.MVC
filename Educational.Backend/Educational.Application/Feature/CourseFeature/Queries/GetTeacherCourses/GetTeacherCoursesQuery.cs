using Educational.Application.Feature.CourseFeature.Queries.GetCourses;
using MediatR;

namespace Educational.Application.Feature.CourseFeature.Queries.GetTeacherCourses
{
    public class GetTeacherCoursesQuery : IRequest<IList<CourseLookupDto>>
    {
        public Guid teacherId { get; set; }
    }
}
