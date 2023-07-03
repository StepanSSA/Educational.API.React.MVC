using MediatR;

namespace Educational.Application.Feature.HomeworkFeatures.Commands.CreateHomework
{
    public class CreateHomeworkCommand : IRequest<Guid>
    {
        public Stream File { get; set; }
        public string FileName { get; set; }
        public Guid UserId { get; set; } 
        public Guid LessonId { get; set; }
    }
}
