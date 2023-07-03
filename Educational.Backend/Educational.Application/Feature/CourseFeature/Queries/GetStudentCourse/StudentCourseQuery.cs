using Educational.Application.Feature.CourseFeature.Queries.GetCourses;
using MediatR;

namespace Educational.Application.Feature.CourseFeature.Queries.GetStudentCourse
{
    public class StudentCourseQuery : IRequest<IList<CourseLookupDto>>
    {
        public Guid UserId { get; set; }     
    }
}
