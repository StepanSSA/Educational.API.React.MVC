using AutoMapper;
using AutoMapper.QueryableExtensions;
using Educational.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.StudentFeatures.Queries.GetStudents
{
    internal class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IList<StudentLookupDto>>
    {
        private readonly IEducationalDbContext context;
        private readonly IMapper mapper;

        public GetStudentsQueryHandler(IEducationalDbContext context, IMapper mapper)
        {
            this.context=context;
            this.mapper=mapper;
        }

        public async Task<IList<StudentLookupDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await context.Students
                .ProjectTo<StudentLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync();
            return students;
        }
    }
}
