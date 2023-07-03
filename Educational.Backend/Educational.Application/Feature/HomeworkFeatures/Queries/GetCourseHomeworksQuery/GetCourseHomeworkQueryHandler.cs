using AutoMapper;
using AutoMapper.QueryableExtensions;
using Educational.Application.Common.Exeptions;
using Educational.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.HomeworkFeatures.Queries.GetCourseHomeworksQuery
{
    internal class GetCourseHomeworkQueryHandler : IRequestHandler<GetCourseHomeworkQuery, IList<CourseHomeworkLookupDto>>
    {
        private readonly IEducationalDbContext context;
        private readonly IMapper mapper;

        public GetCourseHomeworkQueryHandler(IEducationalDbContext context, IMapper mapper)
        {
            this.context=context;
            this.mapper=mapper;
        }

        public async Task<IList<CourseHomeworkLookupDto>> Handle(GetCourseHomeworkQuery request, CancellationToken cancellationToken)
        {
            var homeworks = await context.Homeworks
                .Where(h => h.Lesson.Course.Id == request.CourseId)
                .ProjectTo<CourseHomeworkLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if(homeworks == null)
                throw new NotFoundExeption("Homework for courseId", request.CourseId); 

            return homeworks;
        }
    }
}
