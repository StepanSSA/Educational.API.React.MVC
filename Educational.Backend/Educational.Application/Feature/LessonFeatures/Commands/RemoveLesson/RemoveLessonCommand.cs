using MediatR;

namespace Educational.Application.Feature.LessonFeatures.Commands.RemoveLesson
{
    public class RemoveLessonCommand : IRequest<bool>
    {
        public Guid CourseId { get; set; }
    }
}
