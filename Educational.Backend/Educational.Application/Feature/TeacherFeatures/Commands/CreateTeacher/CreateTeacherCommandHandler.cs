using Educational.Application.Interfaces;
using Educational.Domein;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.TeacherFeatures.Commands.CreateTeacher
{
    internal class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, Guid>
    {
        private readonly IEducationalDbContext context;

        public CreateTeacherCommandHandler(IEducationalDbContext context)
        {
            this.context=context;
        }

        public async Task<Guid> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = new Teacher
            {
                UserId = request.UserId,
                Email = request.Email,
                Lastname = request.Lastname,
                Name = request.Name,
                Course = new List<Course>()
            };

            await context.Teachers.AddAsync(teacher);
            await context.SaveChengesAsync(cancellationToken);

            return teacher.UserId;
        }
    }
}
