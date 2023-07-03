using AutoMapper;
using AutoMapper.QueryableExtensions;
using Educational.Application.Common.Exeptions;
using Educational.Application.Feature.CourseFeature.Queries.GetCourses;
using Educational.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.CourseFeature.Queries.GetTeacherCourses
{
    internal class GetTeacherCourseQueryHandler : IRequestHandler<GetTeacherCoursesQuery, IList<CourseLookupDto>>
    {
        private readonly IEducationalDbContext context;
        private readonly IMapper mapper;

        public GetTeacherCourseQueryHandler(IEducationalDbContext context, IMapper mapper)
        {
            this.context=context;
            this.mapper=mapper;
        }

        public async Task<IList<CourseLookupDto>> Handle(GetTeacherCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await context.Courses
                .Where(c => c.Teacher.UserId == request.teacherId)
                .ProjectTo<CourseLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if(courses == null)
                throw new NotFoundExeption("Course with teacherId", request.teacherId);

            return courses;
        }
    }
}
