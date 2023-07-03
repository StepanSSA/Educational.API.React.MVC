using MediatR;

namespace Educational.Application.Feature.CourseFeature.Commands.UpdateCourse
{
    public class UpdateCourseCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public bool Confirmed { get; set; }
        public virtual Guid TeacherId { get; set; }
    }
}
