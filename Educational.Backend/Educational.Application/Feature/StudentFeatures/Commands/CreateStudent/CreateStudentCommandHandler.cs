using Educational.Application.Interfaces;
using Educational.Domein;
using MediatR;

namespace Educational.Application.Feature.StudentFeatures.Commands.CreateStudent
{
    internal class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
    {
        private readonly IEducationalDbContext context;

        public CreateStudentCommandHandler(IEducationalDbContext context)
        {
            this.context=context;
        }

        public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                Homeworks = new List<Homework>(),
                PurchasedCourses = new List<PurchasedCourses>(),
                UserId = request.UserId,
                Email = request.Email,
                Lastname = request.Lastname,
                Name = request.Name
            };

            await context.Students.AddAsync(student);
            await context.SaveChengesAsync(cancellationToken);

            return student.UserId;
        }
    }
}
