using Educational.Domein;
using MediatR;

namespace Educational.Application.Feature.LessonFeatures.Commands.CreateLesson
{
    public class CreateLessonCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Stream VideoStream { get; set; }
        public int Number { get; set; }
        public Guid CourseId { get; set; }
        public virtual List<Homework> Homeworks { get; set; } = new List<Homework>();
    }
}
