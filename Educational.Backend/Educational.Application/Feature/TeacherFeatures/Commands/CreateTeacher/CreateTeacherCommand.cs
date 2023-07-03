using MediatR;

namespace Educational.Application.Feature.TeacherFeatures.Commands.CreateTeacher
{
    public class CreateTeacherCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
