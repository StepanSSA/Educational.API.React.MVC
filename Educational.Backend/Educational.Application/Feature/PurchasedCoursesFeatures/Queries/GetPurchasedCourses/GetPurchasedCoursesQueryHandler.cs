using AutoMapper;
using AutoMapper.QueryableExtensions;
using Educational.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.PurchasedCoursesFeatures.Queries.GetPurchasedCourses
{
    internal class GetPurchasedCoursesQueryHandler : IRequestHandler<GetPurchasedCoursesQuery, IList<PurchasedCoursesLookupDto>>
    {
        private readonly IEducationalDbContext context;
        private readonly IMapper mapper;

        public GetPurchasedCoursesQueryHandler(IEducationalDbContext context, IMapper mapper)
        {
            this.context=context;
            this.mapper=mapper;
        }

        public async Task<IList<PurchasedCoursesLookupDto>> Handle(GetPurchasedCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await context.PurchasedCourses
                .Where(c => c.Student.UserId == request.UserId).Select(c => c)
                .ProjectTo<PurchasedCoursesLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            
            return courses;
        }
    }
}
