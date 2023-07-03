using Educational.Domein;
using MediatR;

namespace Educational.Application.Feature.StudentFeatures.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
