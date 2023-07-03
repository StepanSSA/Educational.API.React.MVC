using Educational.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.LessonFeatures.Commands.RemoveLesson
{
    internal class RemoveLessonCommandHandler : IRequestHandler<RemoveLessonCommand, bool>
    {

        private readonly IEducationalDbContext context;
        private readonly IFileProvider fileProvider;

        public RemoveLessonCommandHandler(IEducationalDbContext context, IFileProvider fileProvider)
        {
            this.context=context;
            this.fileProvider=fileProvider;
        }

        public async Task<bool> Handle(RemoveLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = await context.Lessons.Where(l => l.Course.Id == request.CourseId).FirstOrDefaultAsync(cancellationToken);

            if(lesson == null) 
                return false;

            if (fileProvider.DeleteLessonVideo(lesson.VideoPath))
            {
                context.Lessons.Remove(lesson);
                return true;
            }

            return false;
        }
    }
}
