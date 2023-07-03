using Educational.Application.Common.Exeptions;
using Educational.Application.Feature.LessonFeatures.Commands.CreateLesson;
using Educational.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.LessonFeatures.Commands.UpdateLessonVideo
{
    internal class UpdateLessonVideoCommandHandler : IRequestHandler<UpdateLessonVideoCommand, bool>
    {

        private readonly IEducationalDbContext context;
        private readonly IFileProvider fileProvider;

        public UpdateLessonVideoCommandHandler(IEducationalDbContext context, IFileProvider fileProvider)
        {
            this.context=context;
            this.fileProvider=fileProvider;
        }

        public async Task<bool> Handle(UpdateLessonVideoCommand request, CancellationToken cancellationToken)
        {
            var lesson = await context.Lessons.Where(l => l.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            if (lesson == null)
                throw new NotFoundExeption(nameof(lesson), request.Id);

            if (!fileProvider.DeleteLessonVideo(lesson.VideoPath))
                return false;

            var path =  fileProvider.SaveLessonVideo(new CreateLessonCommand()
                        {
                            CourseId = lesson.Course.Id,
                            Description = lesson.Description,
                            Name = lesson.Name,
                            VideoStream = request.Video,
                            Id = request.Id,
                        }, lesson.Course.Id.ToString());
            
            lesson.VideoPath = path;

            await context.SaveChengesAsync(cancellationToken);

            return true;
        }
    }
}
