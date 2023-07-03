using AutoMapper;
using AutoMapper.QueryableExtensions;
using Educational.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.HomeworkFeatures.Queries.GetHomeworks
{
    internal class GetHomeworkListQueryHandler : IRequestHandler<GetHomeworkListQuery, IList<HomeworkLookupDto>>
    {
        private readonly IEducationalDbContext context;
        private readonly IMapper mapper;

        public GetHomeworkListQueryHandler(IEducationalDbContext context, IMapper mapper)
        {
            this.context=context;
            this.mapper=mapper;
        }

        public async Task<IList<HomeworkLookupDto>> Handle(GetHomeworkListQuery request, CancellationToken cancellationToken)
        {
            var homework = await context.Homeworks
                .Where(h => h.Student.UserId == request.UserId)
                .Select(h => h)
                .ProjectTo<HomeworkLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            

            return homework;
        }
    }
}
