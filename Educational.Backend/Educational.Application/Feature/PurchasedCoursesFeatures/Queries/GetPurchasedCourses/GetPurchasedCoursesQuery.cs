using MediatR;

namespace Educational.Application.Feature.PurchasedCoursesFeatures.Queries.GetPurchasedCourses
{
    public class GetPurchasedCoursesQuery : IRequest<IList<PurchasedCoursesLookupDto>>
    {
        public Guid UserId { get; set; }
    }
}
