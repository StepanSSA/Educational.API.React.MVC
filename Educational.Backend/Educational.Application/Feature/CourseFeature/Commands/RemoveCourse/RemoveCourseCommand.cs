using MediatR;

namespace Educational.Application.Feature.CourseFeature.Commands.RemoveCourse
{
    public class RemoveCourseCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
