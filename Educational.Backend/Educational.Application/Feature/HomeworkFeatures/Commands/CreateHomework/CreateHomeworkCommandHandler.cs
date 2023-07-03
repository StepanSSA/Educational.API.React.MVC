using Educational.Application.Interfaces;
using Educational.Domein;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Educational.Application.Feature.HomeworkFeatures.Commands.CreateHomework
{
    internal class CreateHomeworkCommandHandler : IRequestHandler<CreateHomeworkCommand, Guid>
    {

        private readonly IEducationalDbContext context;
        private readonly IFileProvider fileProvider;

        public CreateHomeworkCommandHandler(IEducationalDbContext context, IFileProvider fileProvider)
        {
            this.context=context;
            this.fileProvider=fileProvider;
        }

        public async Task<Guid> Handle(CreateHomeworkCommand request, CancellationToken cancellationToken)
        {
            var findeHomework = context.Homeworks
                .Where(h => h.Lesson.Id == request.LessonId && h.Student.UserId == request.UserId)
                .FirstOrDefault();

            if (findeHomework != null)
                return findeHomework.Id;

            var lesson = context.Lessons.Where(l => l.Id == request.LessonId).FirstOrDefault();
            var student = context.Students.Where(s => s.UserId == request.UserId).FirstOrDefault();
            var course = context.Courses.Where(c => c.Lessons.Contains(lesson)).FirstOrDefault();
            var path = fileProvider.SaveStudentHomework(request, lesson.Name, course.Id.ToString());

            var name = path.Split("\\");

            var homework = new Homework
            {
                Id = Guid.NewGuid(),
                date = DateTime.Now,
                FilePath = path,
                Lesson = lesson,
                Score = 0,
                Student = student ?? new Student()
            };

            context.Students.Where(s => s.UserId == request.UserId).Select(s => s.Homeworks).FirstOrDefault().Add(homework);
            
            await context.Homeworks.AddAsync(homework, cancellationToken);
            await context.SaveChengesAsync(cancellationToken);

            return homework.Id;
        }
    }
}
