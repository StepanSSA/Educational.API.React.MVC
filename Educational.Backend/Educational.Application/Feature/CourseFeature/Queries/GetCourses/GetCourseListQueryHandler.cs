using AutoMapper;
using AutoMapper.QueryableExtensions;
using Educational.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.CourseFeature.Queries.GetCourses
{
    public class GetCourseListQueryHandler : IRequestHandler<GetCourseListQuery, IList<CourseLookupDto>>
    {
        private readonly IEducationalDbContext context;
        private readonly IMapper mapper;

        public GetCourseListQueryHandler(IEducationalDbContext context, IMapper mapper)
        {
            this.context=context;
            this.mapper=mapper;
        }

        public async Task<IList<CourseLookupDto>> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
        {
            var courses = await context.Courses
                .Select(x => x)
                .ProjectTo<CourseLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return courses;
        }
    }
}
