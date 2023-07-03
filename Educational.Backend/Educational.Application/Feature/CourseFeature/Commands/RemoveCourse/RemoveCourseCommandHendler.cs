using Educational.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.CourseFeature.Commands.RemoveCourse
{
    public class RemoveCourseCommandHendler : IRequestHandler<RemoveCourseCommand, bool>
    {
        private readonly IEducationalDbContext context;
        private readonly IFileProvider fileProvider;

        public RemoveCourseCommandHendler(IEducationalDbContext context, IFileProvider fileProvider)
        {
            this.context=context;
            this.fileProvider=fileProvider;
        }

        public async Task<bool> Handle(RemoveCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await context.Courses.FindAsync(new object[] { request.Id }, cancellationToken);
            if (course == null) 
            {
                return false;
            }
            var lessons = await context.Lessons.Where(l => l.Course.Id == request.Id).Select(l => l).ToListAsync(cancellationToken);

            if (lessons.Any())
            {
                if (!fileProvider.DeleteCourse(request.Id.ToString()))
                    return false;     
                
                context.Lessons.RemoveRange(lessons);
            }

            context.Courses.Remove(course);

            await context.SaveChengesAsync(cancellationToken);

            return true;
        }
    }
}
