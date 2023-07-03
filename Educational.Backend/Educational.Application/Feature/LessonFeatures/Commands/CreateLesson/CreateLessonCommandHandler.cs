using Educational.Application.Interfaces;
using Educational.Domein;
using MediatR;

namespace Educational.Application.Feature.LessonFeatures.Commands.CreateLesson
{
    internal class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, Guid>
    {
        private readonly IEducationalDbContext context;
        private readonly IFileProvider fileProvider;

        public CreateLessonCommandHandler(IEducationalDbContext context, IFileProvider fileProvider)
        {
            this.context=context;
            this.fileProvider=fileProvider;
        }

        public async Task<Guid> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            var course = context.Courses.Where(c => c.Id == request.CourseId).FirstOrDefault();
            string path = fileProvider.SaveLessonVideo(request, course.Id.ToString());
            var lesson = new Lesson
            {
                Id = request.Id,
                Description = request.Description,
                Name = request.Name,
                Course = course,
                Homeworks = request.Homeworks,
                VideoPath = path,
                Number = request.Number,
            };

            await context.Lessons.AddAsync(lesson, cancellationToken);
            await context.SaveChengesAsync(cancellationToken);

            return lesson.Id;
        }
    }
}
