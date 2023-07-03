using MediatR;

namespace Educational.Application.Feature.HomeworkFeatures.Queries.GetCourseHomeworksQuery
{
    public class GetCourseHomeworkQuery : IRequest<IList<CourseHomeworkLookupDto>>
    {
        public Guid CourseId { get; set; }
    }
}
