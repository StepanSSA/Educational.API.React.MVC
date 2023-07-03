using MediatR;

namespace Educational.Application.Feature.LessonFeatures.Commands.UpdateLessonVideo
{
    internal class UpdateLessonVideoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string VideoPath { get; set; }
        public Stream Video { get; set; }
    }
}
