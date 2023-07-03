using AutoMapper;
using AutoMapper.QueryableExtensions;
using Educational.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.LessonFeatures.Queries.GetLessons
{
    internal class GetLessonListQueryHandler : IRequestHandler<GetLessonListQuery, IList<LessonLookupDto>>
    {
        private readonly IEducationalDbContext context;
        private readonly IMapper mapper;

        public GetLessonListQueryHandler(IEducationalDbContext context, IMapper mediator)
        {
            this.context=context;
            this.mapper=mediator;
        }
        public async Task<IList<LessonLookupDto>> Handle(GetLessonListQuery request, CancellationToken cancellationToken)
        {
            var lessons = await context.Lessons
                .ProjectTo<LessonLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            
            return lessons;
        }
    }
}
