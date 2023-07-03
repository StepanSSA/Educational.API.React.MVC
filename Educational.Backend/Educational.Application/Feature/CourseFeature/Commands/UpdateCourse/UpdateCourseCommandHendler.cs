using Educational.Application.Common.Exeptions;
using Educational.Application.Interfaces;
using Educational.Domein;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.CourseFeature.Commands.UpdateCourse
{
    public class UpdateCourseCommandHendler : IRequestHandler<UpdateCourseCommand, bool>
    {
        private readonly IEducationalDbContext context;

        public UpdateCourseCommandHendler(IEducationalDbContext context)
        {
            this.context=context;
        }

        public async Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await context.Courses.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (course == null) 
            {
                throw new NotFoundExeption(nameof(Course), request.Id);
            }

            var teacher = await context.Teachers.Where(t => t.UserId == request.TeacherId).FirstOrDefaultAsync(cancellationToken);

            if (teacher == null)
            {
                throw new NotFoundExeption(nameof(Teacher), request.TeacherId);
            }

            course.Description = request.Description;
            course.Duration = request.Duration;
            course.Name = request.Name;
            course.Price = request.Price;
            course.Teacher = teacher;
            course.Confirmed = request.Confirmed;

            await context.SaveChengesAsync(cancellationToken);

            return true;
        }
    }
}
