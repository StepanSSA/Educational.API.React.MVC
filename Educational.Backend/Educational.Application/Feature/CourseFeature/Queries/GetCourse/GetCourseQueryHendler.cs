using AutoMapper;
using Educational.Application.Common.Exeptions;
using Educational.Application.Interfaces;
using Educational.Domein;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.CourseFeature.Queries.GetCourse
{
    public class GetCourseQueryHendler : IRequestHandler<GetCourseQuery, CourseDetailVm>
    {
        private readonly IEducationalDbContext context;
        private readonly IMapper mapper;

        public GetCourseQueryHendler(IEducationalDbContext context, IMapper mapper)
        {
            this.context=context;
            this.mapper=mapper;
        }


        public async Task<CourseDetailVm> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await context.Courses.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            
            if(course == null) 
            {
                throw new NotFoundExeption(nameof(Course), request.Id);
            }

            return mapper.Map<CourseDetailVm>(course);
        }
    }
}
