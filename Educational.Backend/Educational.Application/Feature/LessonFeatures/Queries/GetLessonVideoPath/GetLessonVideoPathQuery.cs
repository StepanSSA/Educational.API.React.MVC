using MediatR;

namespace Educational.Application.Feature.LessonFeatures.Queries.GetLessonVideoPath
{
    public class GetLessonVideoPathQuery : IRequest<string>
    {
        public Guid lessonId { get; set; }

    }
}
