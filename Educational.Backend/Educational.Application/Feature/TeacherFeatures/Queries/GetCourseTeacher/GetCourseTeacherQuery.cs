using MediatR;

namespace Educational.Application.Feature.TeacherFeatures.Queries.GetCourseTeacher
{
    public class GetCourseTeacherQuery : IRequest<TeacherForCourseDetailVm>
    {
        public Guid CourseId { get; set; }
    }
}
