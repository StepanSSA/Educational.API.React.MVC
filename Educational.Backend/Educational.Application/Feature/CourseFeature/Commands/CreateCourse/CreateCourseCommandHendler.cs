using AutoMapper;
using Educational.Application.Interfaces;
using Educational.Domein;
using MediatR;

namespace Educational.Application.Feature.CourseFeature.Commands.CreateCourse
{
    internal class CreateCourseCommandHendler : IRequestHandler<CreateCourseCommand, Guid>
    {
        private readonly IEducationalDbContext context;
        private readonly IMapper mapper;

        public CreateCourseCommandHendler(IEducationalDbContext context, IMapper mapper)
        {
            this.context=context;
            this.mapper=mapper;
        }

        public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var teacher = context.Teachers.Where(t => t.UserId == request.TeacherId).FirstOrDefault();

            var course = new Course
            {
                Id = request.Id,
                Description = request.Description,
                Duration = request.Duration,
                Name = request.Name,
                Price = request.Price,
                Teacher = teacher ?? new Teacher()
            };

            await context.Courses.AddAsync(course, cancellationToken);
            await context.SaveChengesAsync(cancellationToken);

            return course.Id;
        }
    }
}
