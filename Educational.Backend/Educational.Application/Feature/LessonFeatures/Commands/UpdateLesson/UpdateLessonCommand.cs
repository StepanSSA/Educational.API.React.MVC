using MediatR;

namespace Educational.Application.Feature.LessonFeatures.Commands.UpdateLesson
{
    public class UpdateLessonCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
    }
}