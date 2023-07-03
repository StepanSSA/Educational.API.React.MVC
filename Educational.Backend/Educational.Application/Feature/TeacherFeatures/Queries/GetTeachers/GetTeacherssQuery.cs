using Educational.Application.Feature.TeacherFeatures.Queries.GetCourseTeacher;
using MediatR;

namespace Educational.Application.Feature.TeacherFeatures.Queries.GetTeachers
{
    public class GetTeacherssQuery : IRequest<IList<TeacherForCourseDetailVm>>
    {
    }
}
