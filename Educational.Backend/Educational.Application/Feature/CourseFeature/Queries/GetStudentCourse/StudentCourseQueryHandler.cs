using AutoMapper;
using AutoMapper.QueryableExtensions;
using Educational.Application.Feature.CourseFeature.Queries.GetCourses;
using Educational.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.CourseFeature.Queries.GetStudentCourse
{
    internal class StudentCourseQueryHandler : IRequestHandler<StudentCourseQuery, IList<CourseLookupDto>>
    {
        private readonly IEducationalDbContext context;
        private readonly IMapper mapper;

        public StudentCourseQueryHandler(IEducationalDbContext context, IMapper mapper)
        {
            this.context=context;
            this.mapper=mapper;
        }

        public async Task<IList<CourseLookupDto>> Handle(StudentCourseQuery request, CancellationToken cancellationToken)
        {
            var studentCourse = await context.PurchasedCourses
                .Where(c => c.Student.UserId == request.UserId)
                .Select(c => c.Course)
                .ProjectTo<CourseLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return studentCourse;
        }
    }
}
