using Educational.Application.Common.Exeptions;
using Educational.Application.Interfaces;
using Educational.Domein;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.LessonFeatures.Commands.UpdateLesson
{
    internal class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand>
    {

        private readonly IEducationalDbContext context;

        public UpdateLessonCommandHandler(IEducationalDbContext context)
        {
            this.context=context;
        }

        public async Task Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = await context.Lessons
                .Where(l => l.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (lesson == null)
            {
                throw new NotFoundExeption(nameof(Lesson), request.Id);
            }

            lesson.Name = request.Name ?? lesson.Name;
            lesson.Description = request.Description ?? lesson.Description;
            lesson.Number = request.Number;

            await context.SaveChengesAsync(cancellationToken);
        }
    }
}
